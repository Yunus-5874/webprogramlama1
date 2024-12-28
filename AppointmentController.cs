using Microsoft.AspNetCore.Mvc;
using BerberWebSitesi.Data;
using BerberWebSitesi.Models;
using System.Linq;

namespace BerberWebSitesi.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly BerberContext _context;

        public AppointmentController(BerberContext context)
        {
            _context = context;
        }

        // Randevu formunu göster
        public IActionResult Create()
        {
            ViewBag.Services = _context.Services.ToList();
            ViewBag.Employees = _context.Employees.ToList();
            ViewBag.Customers = _context.Customers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            var service = _context.Services.Find(appointment.ServiceId);
            var employee = _context.Employees.Find(appointment.EmployeeId);

            // Çalışanın yetkinliklerini kontrol et
            if (!employee.JobTitle.Split(", ").Contains(service.Name))
            {
                ModelState.AddModelError("", $"Bu çalışan {service.Name} işlemini yapmıyor.");
                ViewBag.Services = _context.Services.ToList();
                ViewBag.Employees = _context.Employees.ToList();
                ViewBag.Customers = _context.Customers.ToList();
                return View(appointment);
            }

            // Aynı çalışan ve saat için çakışma kontrolü
            var overlappingAppointments = _context.Appointments
                .Where(a => a.EmployeeId == appointment.EmployeeId && a.Date == appointment.Date)
                .OrderBy(a => a.StartTime)
                .ToList();

            foreach (var existingAppointment in overlappingAppointments)
            {
                if ((appointment.StartTime >= existingAppointment.StartTime && appointment.StartTime < existingAppointment.EndTime) ||
                    (appointment.EndTime > existingAppointment.StartTime && appointment.EndTime <= existingAppointment.EndTime))
                {
                    var lastEndTime = overlappingAppointments.Last().EndTime;
                    ModelState.AddModelError("", $"Bu çalışan seçilen saatlerde dolu. Bir sonraki uygun saat: {lastEndTime}");
                    ViewBag.NextAvailableTime = lastEndTime;
                    ViewBag.Services = _context.Services.ToList();
                    ViewBag.Employees = _context.Employees.ToList();
                    ViewBag.Customers = _context.Customers.ToList();
                    return View(appointment);
                }
            }

            appointment.EndTime = appointment.StartTime + service.Duration;
            appointment.Price = service.Price;

            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Services = _context.Services.ToList();
            ViewBag.Employees = _context.Employees.ToList();
            ViewBag.Customers = _context.Customers.ToList();
            return View(appointment);
        }
    }
}

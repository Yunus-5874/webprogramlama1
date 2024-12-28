using Microsoft.AspNetCore.Mvc;
using BerberWebSitesi.Data;
using BerberWebSitesi.Models;
using System.Linq;

namespace BerberWebSitesi.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly BerberContext _context;

        public EmployeeController(BerberContext context)
        {
            _context = context;
        }

        // Çalışan listeleme
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
    }
}

// Appointment.cs
using System.ComponentModel.DataAnnotations;

namespace BerberWebSitesi.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal Price { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace BerberWebSitesi.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string WorkDays { get; set; }

        [Required]
        public string WorkHours { get; set; }

        public string LeaveDays { get; set; }
    }
}

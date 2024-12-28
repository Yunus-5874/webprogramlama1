using System.ComponentModel.DataAnnotations;

namespace BerberWebSitesi.Models
{
    public class Barber
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "İsim zorunludur.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Uzmanlık alanı zorunludur.")]
        public string Specialty { get; set; }

        [Required(ErrorMessage = "Çalışma saatleri zorunludur.")]
        public string WorkingHours { get; set; }
    }
}

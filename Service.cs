// Service.cs
using System.ComponentModel.DataAnnotations;

namespace BerberWebSitesi.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
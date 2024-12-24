using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarberShop1._0._1.Web.Models
{
    public class ServiceModel
    {
        public int Id { get; set; } // Primary Key
        [Display(Name = "Hizmet")]
        public string Name { get; set; } // Name of the service (e.g., haircut, beard grooming)
        [Display(Name = "Fiyat")]
        public double Price { get; set; } // Service price
        [Display(Name = "Süre")]
        public int DurationInMinutes { get; set; } // Duration of the service

        // Navigation property for many-to-many relationship
        public ICollection<Barber>? Barbers { get; set; }
        // In ServiceModel or a small separate ViewModel that includes ServiceModel data
        public int? SelectedBarberId { get; set; }
        public int? SelectedTimeSlotId { get; set; }

    }
}

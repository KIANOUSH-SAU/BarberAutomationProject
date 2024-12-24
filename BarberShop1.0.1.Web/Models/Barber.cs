using System.ComponentModel.DataAnnotations;

namespace BarberShop1._0._1.Web.Models
{
    public class Barber
    {
        public int Id { get; set; } // Primary Key
        [Display(Name = "Adı")]
        public string Name { get; set; } // Barber's Name
        [Display(Name = "Telefon numarası")]
        public string PhoneNumber { get; set; } // Barber's Contact Information (optional)
        [Display(Name = "Hizmetler")]
        public ICollection<ServiceModel> Services { get; set; } = new List<ServiceModel>();
        [Display(Name = "Çalışma saatleri")]
        public ICollection<BarberAvailability> Availabilities { get; set; } = new List<BarberAvailability>();
    }
}

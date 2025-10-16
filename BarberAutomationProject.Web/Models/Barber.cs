using System.ComponentModel.DataAnnotations;

namespace BarberAutomationProject.Web.Models
{
    public class Barber
    {
        public int Id { get; set; } // Primary Key
        [Display(Name = "Adı")]
        public string Name { get; set; } // Barber's Name
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; } // Barber's Contact Information (optional)
        [Display(Name = "Hizmetler")]
        public ICollection<ServiceModel> Services { get; set; } = new List<ServiceModel>();
        [Display(Name = "Çalışma Saatleri")]
        public ICollection<BarberAvailability> Availabilities { get; set; } = new List<BarberAvailability>();
    }
}

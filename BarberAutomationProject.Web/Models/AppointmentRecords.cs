using System.ComponentModel.DataAnnotations;

namespace BarberAutomationProject.Web.Models
{
    public class AppointmentRecords
    {
        public int Id { get; set; }
        public int BarberId { get; set; }
        [Display(Name = "Berber")]
        public Barber Barber { get; set; }

        public int ServiceId { get; set; }
        [Display(Name = "Hizmet")]
        public ServiceModel Service { get; set; }
        [Display(Name = "Müşteri Adı")]
        public string? CustomerName { get; set; }
        [Display(Name = "Müşteri Soyadı")]
        public string? CustomerSurname { get; set; }
        [Display(Name = "Müşteri E-Postası")]
        public string? CustomerEmail { get; set; }
        [Display(Name = "Randevu Saati")]
        public DateTime AppointmentDateTime { get; set; }

        public string ConfirmationToken { get; set; }
        [Display(Name = "Randevu Onaylanma Durumu")]
        public bool IsConfirmed { get; set; }
    }
}

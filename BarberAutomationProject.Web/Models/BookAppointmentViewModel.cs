using System.ComponentModel.DataAnnotations;

namespace BarberShop1._0._1.Web.Models;

public class BookAppointmentViewModel
{
    public int SelectedServiceId { get; set; }

    [Required(ErrorMessage = "Saat Seçimi gereklidir.")]
    public int? SelectedTimeSlotId { get; set; }


    [Required(ErrorMessage = "Berber Seçimi gereklidir.")]
    public int? SelectedBarberId { get; set; }
    public ServiceModel Service { get; set; } = new ServiceModel();

    public ICollection<Barber> ?Barbers { get; set; }

    public ICollection<BarberAvailability>? Availabilities { get; set; }
    [Display(Name = "Adınız:")]
    [Required(ErrorMessage = "Ad alanı gereklidir.")]
    public string? CustomerName { get; set; }

    [Display(Name = "Soyadınız:")]
    [Required(ErrorMessage = "Soyad alanı gereklidir.")]
    public string? CustomerSurname { get; set; }
    [Display(Name = "E-Postanız:")]
    [Required(ErrorMessage = "E-Posta adresi gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
    public string? CustomerEmail { get; set; }
}
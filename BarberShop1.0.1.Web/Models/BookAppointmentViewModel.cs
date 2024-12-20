namespace BarberShop1._0._1.Web.Models;

public class BookAppointmentViewModel
{
    public int SelectedServiceId { get; set; }
    public int? SelectedTimeSlotId { get; set; }
    public int? SelectedBarberId { get; set; }
    public ServiceModel Service { get; set; } = new ServiceModel();
    public ICollection<Barber> ?Barbers { get; set; }
    public ICollection<BarberAvailability>? Availabilities { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerSurname { get; set; }
    public string? CustomerEmail { get; set; }
}
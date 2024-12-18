namespace BarberShop1._0._1.Web.Models;

public class BookAppointmentViewModel
{
    public ServiceModel Service { get; set; }
    public ICollection<Barber> Barbers { get; set; }
    public ICollection<BarberAvailability> Availabilities { get; set; }
    public int? SelectedBarberId { get; set; }
}
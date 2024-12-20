namespace BarberShop1._0._1.Web.Models
{
    public class AppointmentRecords
    {
        public int Id { get; set; }
        public int BarberId { get; set; }
        public Barber Barber { get; set; }

        public int ServiceId { get; set; }
        public ServiceModel Service { get; set; }

        public string? CustomerName { get; set; }
        public string? CustomerSurname { get; set; }
        public string? CustomerEmail { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public string ConfirmationToken { get; set; }
        public bool IsConfirmed { get; set; }
    }
}

namespace BarberAutomationProject.Web.Models
{
    public class BarberAvailability
    {
        public int Id { get; set; } // Primary Key
        public int BarberId { get; set; } // Foreign Key
        public Barber Barber { get; set; } // Navigation property
        public DateTime AvailableFrom { get; set; } // Start of available time
        public DateTime AvailableTo { get; set; } // End of available time

        public bool IsBooked { get; set; } // To track if this slot is already booked
    }
}

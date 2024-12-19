namespace BarberShop1._0._1.Web.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public Barber Barber { get; set; } // Navigation property
        public BarberAvailability BarberAvailability { get; set; }
    }
}

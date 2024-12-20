namespace BarberShop1._0._1.Web.Models
{
    public class Barber
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Barber's Name
        public string PhoneNumber { get; set; } // Barber's Contact Information (optional)
        public ICollection<ServiceModel> Services { get; set; } = new List<ServiceModel>();

        public ICollection<BarberAvailability> Availabilities { get; set; } = new List<BarberAvailability>();
    }
}

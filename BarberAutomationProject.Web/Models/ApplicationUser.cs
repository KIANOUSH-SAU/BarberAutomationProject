using Microsoft.AspNetCore.Identity;

namespace BarberShop1._0._1.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}

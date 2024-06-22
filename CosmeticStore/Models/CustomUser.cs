using Microsoft.AspNetCore.Identity;

namespace BeautyCareStore.Models
{
    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

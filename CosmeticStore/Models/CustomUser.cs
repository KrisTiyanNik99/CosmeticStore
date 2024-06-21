using Microsoft.AspNetCore.Identity;

namespace CosmeticStore.Models
{
    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;


namespace MyDotNetIsBetterThanYours.Domain.Models
{

    public class AppUser : IdentityUser
    {
        public User User { get; set; }
    }

}
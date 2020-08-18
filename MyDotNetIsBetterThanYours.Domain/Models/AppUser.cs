using Microsoft.AspNetCore.Identity;


namespace MyDotNetIsBetterThanYours.Domain.Models
{

    public class AppUser : IdentityUser
    {
        public User User { get; set; }

        public AppUser()
        {
            User = new User();

            // User.AppUserId = Id;
            User.AnwswersPoints = 0;
            User.QuestionPoints = 0;
        }
    }

}
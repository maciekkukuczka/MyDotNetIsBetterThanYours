using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MyDotNetIsBetterThanYours.Domain.Base;


namespace MyDotNetIsBetterThanYours.Domain.Models
{

    // public class AppUser:IdentityUser
    // {
    //     public User User { get; set; }
    // }


    public class User : BaseEntity
    {
        // public bool IsActive { get; set; } = true;
        public int Points { get; set; }

        [ForeignKey("AppUser")] public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public virtual List<Question> Questions { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }

}
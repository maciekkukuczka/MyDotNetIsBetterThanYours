using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MyDotNetIsBetterThanYours.Domain.Base;


namespace MyDotNetIsBetterThanYours.Domain.Models
{

    public class User : BaseEntity
    {
        public int AnwswersPoints { get; set; }
        public int QuestionPoints { get; set; }

        [ForeignKey("AppUser")] public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public virtual List<Question> Questions { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }

}
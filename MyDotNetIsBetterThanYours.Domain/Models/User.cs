using System.Collections.Generic;
using MyDotNetIsBetterThanYours.Domain.Base;


namespace MyDotNetIsBetterThanYours.Domain.Models
{

    public class User : BaseEntity
    {
        // public bool IsActive { get; set; }

        public int Points { get; set; }

        private List<Question> Questions { get; set; }
        private List<Answer> Answers { get; set; }
    }

}
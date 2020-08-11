using System.Collections.Generic;
using MyDotNetIsBetterThanYours.Domain.Base;


namespace MyDotNetIsBetterThanYours.Domain.Models
{

    public class Question : BaseEntity
    {
        public string Content { get; set; }

        public User User { get; set; }
        public List<Answer> Answers { get; set; }
    }

}
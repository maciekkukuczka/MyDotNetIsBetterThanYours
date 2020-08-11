using MyDotNetIsBetterThanYours.Domain.Base;


namespace MyDotNetIsBetterThanYours.Domain.Models
{

    public class Answer : BaseEntity
    {
        public string Content { get; set; }

        public User User { get; set; }
        public Question Question { get; set; }
    }

}
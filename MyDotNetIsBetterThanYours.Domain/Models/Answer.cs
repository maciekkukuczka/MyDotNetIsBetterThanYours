using System.ComponentModel.DataAnnotations;
using MyDotNetIsBetterThanYours.Domain.Base;


namespace MyDotNetIsBetterThanYours.Domain.Models
{

    public class Answer : BaseEntity
    {
        [Required(ErrorMessage = "To pole nie może być puste!")]
        [StringLength(10000, ErrorMessage = "Wpis nie może przekraczać 100 znaków!")]
        [Display(Name = "Treść odpowiedzi")]
        public string Content { get; set; }

        public User User { get; set; }
        public Question Question { get; set; }
    }

}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyDotNetIsBetterThanYours.Domain.Base;


namespace MyDotNetIsBetterThanYours.Domain.Models
{

    public class Question : BaseEntity
    {
        [Required(ErrorMessage = "To pole nie może być puste!")]
        [StringLength(100, ErrorMessage = "Wpis nie może przekraczać 100 znaków!")]
        [Display(Name = "Treść pytania")]
        public string Content { get; set; }

        public User User { get; set; }

        [ValidateComplexType] public virtual List<Answer> Answers { get; set; }
    }

}
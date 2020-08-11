using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace MyDotNetIsBetterThanYours.Domain.Models
{

    public class User : IdentityUser /*: BaseEntity*/
    {
        public bool IsActive { get; set; }

        public int Points { get; set; }

        private List<Question> Questions { get; set; }
        private List<Answer> Answers { get; set; }
    }

}
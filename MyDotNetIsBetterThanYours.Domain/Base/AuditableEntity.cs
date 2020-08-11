using System;
using Microsoft.AspNetCore.Identity;


namespace MyDotNetIsBetterThanYours.Domain.Base
{

    public class AuditableEntity : IdentityUser
    {
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }

}
using System;


namespace MyDotNetIsBetterThanYours.Domain.Base
{

    public class AuditableEntity
    {
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }

}
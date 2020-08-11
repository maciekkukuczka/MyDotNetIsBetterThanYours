using System;


namespace MyDotNetIsBetterThanYours.Domain.Base
{

    public class BaseEntity : AuditableEntity
    {
        public string Id { get; set; } = new Guid().ToString();
        public bool IsActive { get; set; }
    }

}
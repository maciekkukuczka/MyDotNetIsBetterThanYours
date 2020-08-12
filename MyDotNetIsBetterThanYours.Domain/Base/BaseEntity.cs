using System;


namespace MyDotNetIsBetterThanYours.Domain.Base
{

    public class BaseEntity : AuditableEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsActive { get; set; } = true;
    }

}
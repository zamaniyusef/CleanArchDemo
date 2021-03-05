namespace CleanArch.Domain.Base
{
    using System;
    public class BaseEntityIsActive : BaseEntity
    {
        public BaseEntityIsActive()
        {
            ActiveDate = DateTime.Now;
        }

        public bool IsActive { get; set; }
        public DateTime ActiveDate { get; set; }
    }
}
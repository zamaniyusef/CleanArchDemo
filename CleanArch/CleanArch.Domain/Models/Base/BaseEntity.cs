namespace CleanArch.Domain.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class BaseEntity : EntityId
    {
        public BaseEntity()
        {
            DateTime dtmNow = DateTime.Now;
            InsertTime = dtmNow;
            UpdateTime = dtmNow;
        }

        [ScaffoldColumn(scaffold: false)]
        public DateTime InsertTime { get; set; }
        [ScaffoldColumn(scaffold: false)]
        public DateTime UpdateTime { get; set; }
        [ScaffoldColumn(scaffold: false)]
        public bool IsDeleted { get; set; }
        [ScaffoldColumn(scaffold: false)]
        public DateTime? DeletedTime { get; set; }
    }
}
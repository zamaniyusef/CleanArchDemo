namespace CleanArch.Domain.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class EntityId
    {
        public EntityId()
        {
            ID = Guid.NewGuid();
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ScaffoldColumn(scaffold: false)]
        public Guid ID { get; set; }
    }
}
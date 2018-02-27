using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public abstract class AuditableEntity
    {
        public Guid? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual User Creator { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual User Updator { get; set; }
    }
}

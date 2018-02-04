using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class ExtraClassEntity
    {

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Guid? UpdateBy { get; set; }

        public Guid? CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual User Creator { get; set; }

        [ForeignKey("UpdateBy")]
        public virtual User Updator { get; set; }
    }
}

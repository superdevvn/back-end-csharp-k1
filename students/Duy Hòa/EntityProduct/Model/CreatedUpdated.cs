using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class CreatedUpdated
    {
        public Guid? CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime UpdateDate { get; set; }

        [ForeignKey("CreateBy")]
        public virtual User Create { get; set; }

        [ForeignKey("UpdateBy")]
        public virtual User Update { get; set; }
    }
}

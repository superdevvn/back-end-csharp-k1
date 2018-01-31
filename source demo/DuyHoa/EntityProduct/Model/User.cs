using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CreateBy { get; set; }

        [ForeignKey("CreateBy")]
        public virtual User Users { get; set; }
    }
}

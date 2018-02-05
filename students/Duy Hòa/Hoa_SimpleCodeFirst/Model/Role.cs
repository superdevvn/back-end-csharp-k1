using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model
{
    public class Role
    {
        public Guid ID { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual List<User> Users { get; set; }
    }
}

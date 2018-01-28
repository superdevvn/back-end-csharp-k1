using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Orderline
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product proroduct { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Orderline : ExtraClassEntity
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid OrderId { get; set; }

        public int Quanity { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        
    }
}

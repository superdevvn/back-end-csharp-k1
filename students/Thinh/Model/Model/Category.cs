using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category: AuditableEntity
    {
        public Guid Id { get; set; }
        [StringLength(15)]
        public string Name { get; set; }
        [StringLength(30)]
        public string description { get; set; }
    }
}

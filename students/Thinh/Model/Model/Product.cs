using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product : AuditableEntity
    {
        public Guid Id { get; set; }

        [Index("IX_Code", 1, IsUnique = true)]
        public Guid CategoryId { get; set; }
        public Guid? ManufacterId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("ManufacterId")]
        public virtual Manufacter Manufacter { get; set; }
    }
    public class ProductComlex {
        public Guid Id { get; set; }
        public Guid Category { get; set; }
        public string CategoryName { get; set; }
        public Guid? CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public Guid? UpdateBy { get; set; }
        public string UpdatedName { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? ManufacterId { get; set; }

        public string ManufacterName { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

    }
}

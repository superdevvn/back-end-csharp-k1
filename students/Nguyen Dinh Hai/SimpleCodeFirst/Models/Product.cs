using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Product:AuditableEntity
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public Guid? ManufacturerId { get; set; }

        [StringLength(15)]
        [Index("IX_Code", 1, IsUnique = true)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }
    }

    public class ProductComplex
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        public Guid? ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public Guid? CreatedBy { get; set; }

        public string CreatedName { get; set; }

        public Guid? UpdatedBy { get; set; }

        public string UpdatedName { get; set; }
    }
}

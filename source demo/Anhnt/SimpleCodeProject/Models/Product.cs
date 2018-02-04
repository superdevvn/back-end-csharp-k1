using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Product : ExtraClassEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public Guid? CategoryId { get; set; }

        public Guid? ManufacturerId { get; set; }

        public string Code { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }



        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }
    }

    public class ProductComplex : ExtraClassEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ManufacturerName { get; set; }

        public Guid? ManufacturerId { get; set; }

        public Guid? CategoryId { get; set; }

        public string CreatedName { get; set; }

        public string UpdateName { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }

        public string Code { get; set; }
    }
}


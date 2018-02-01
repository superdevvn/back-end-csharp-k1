using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Product : CreatedUpdated
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public Guid? ManufacturerId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }


    }
}

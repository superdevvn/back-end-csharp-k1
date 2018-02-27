using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Category:AuditableEntity
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
    }
}

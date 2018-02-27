using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Manufacturer:AuditableEntity
    {
        public Guid Id { get; set; }

        [StringLength(15)]
        [Index("IX_Code", 1, IsUnique = true)]
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}

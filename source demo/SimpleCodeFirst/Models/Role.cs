using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Role
    {
        public Guid Id { get; set; }

        [StringLength(15)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual List<User> Users { get; set; }
    }
}

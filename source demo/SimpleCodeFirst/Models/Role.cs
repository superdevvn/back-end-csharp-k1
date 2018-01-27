﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Role
    {
        public Guid Id { get; set; }

        [StringLength(15)]
        [Index("IX_Code", 1, IsUnique = true)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual List<User> Users { get; set; }
    }
}

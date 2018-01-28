﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Manufacter: AuditableEntity
    {
        public Guid Id { get; set; }
        [StringLength(15)]
        [Index("IX_Code", 1, IsUnique = true)]
        public string Code { get; set; }
        [StringLength(15)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
    }
}

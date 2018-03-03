using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDev.Models
{
    public partial class SuperDevDbContext
    {
        public DbSet<WorkOn> WorkOns { get; set; }
    }
    public class WorkOn
    {
        [Key, Column(Order = 1)]
        public int EmployeeId { get; set; }

        [Key, Column(Order = 2)]
        public int ProjectId { get; set; }

        public double Hours { get; set; }

        public WorkOn() { }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
}

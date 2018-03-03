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
        public DbSet<Project> Projects { get; set; }
    }
    public class Project
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public int DepartmentId { get; set; }

        [Index("IX_Code", IsUnique = true)]
        [MaxLength(50)]
        public string Code { get; set; }

        public string Name { get; set; }

        public Project() { }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
    }
}

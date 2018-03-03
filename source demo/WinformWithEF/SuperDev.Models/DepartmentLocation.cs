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
        public DbSet<DepartmentLocation> DepartmentLocations { get; set; }
    }

    public class DepartmentLocation
    {
        [Key, Column(Order = 1)]
        public int DepartmentId { get; set; }
        [Key, Column(Order = 2)]
        public int LocationId { get; set; }

        public DepartmentLocation()
        {

        }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
    }
}

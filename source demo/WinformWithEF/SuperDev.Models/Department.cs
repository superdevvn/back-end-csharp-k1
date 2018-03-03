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
        public DbSet<Department> Departments { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }

        [Index("IX_Code", IsUnique = true)]
        [MaxLength(50)]
        public string Code { get; set; }

        public string Name { get; set; }

        public string SSN { get; set; }

        public DateTime AssDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDev.Models
{
    public partial class SuperDevDbContext
    {
        public DbSet<Dependent> Dependents { get; set; }
    }
    public class Dependent
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public DateTime Birthdate { get; set; }

        public string Relationship { get; set; }

        public Dependent() { }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SamplePaging.Models
{

    public partial class SuperDevDbContext
    {
        public DbSet<Demo> Demos { get; set; }
    }
    public class Demo
    {
        public int Id { get; set; }

        public int? RoleId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public int Salary { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}

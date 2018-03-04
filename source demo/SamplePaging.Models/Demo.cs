using System;
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

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public int Salary { get; set; }

        public bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePaging.Models
{
    public partial class SuperDevDbContext
    {
        public DbSet<Role> Roles { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public virtual List<Demo> Demos { get; set; }
    }
}

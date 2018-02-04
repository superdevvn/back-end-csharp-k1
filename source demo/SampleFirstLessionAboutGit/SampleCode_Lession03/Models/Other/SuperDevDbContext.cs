using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Other
{
    public class SuperDevDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public SuperDevDbContext():base("Data Source=(local);Initial Catalog=CodeFirst2;Integrated Security=True")
        {

        }
    }
}

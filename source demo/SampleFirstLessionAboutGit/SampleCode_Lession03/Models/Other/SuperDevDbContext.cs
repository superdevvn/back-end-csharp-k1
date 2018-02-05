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
        public SuperDevDbContext():base("Data Source=DESKTOP-RB5AHK0;Initial Catalog=CodeFirst1;Persist Security Info=True;User ID=sa;Password=1")
        {

        }
    }
}

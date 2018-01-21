using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Other
{
    public class SuperDBContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public SuperDBContext()
            : base("Data Source=THINHPHSE62039\\SQLEXPRESS;Initial Catalog=SimpleCodeFirst;Integrated Security=True")
        {

        }
    }
}

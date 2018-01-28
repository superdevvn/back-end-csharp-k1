using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Other
{
    public class SuperDBContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacter> Manufacters { get; set; }
        public DbSet<Orderline> Orderlines { get; set; }
        public SuperDBContext()
           : base("Data Source=THINHPHSE62039\\SQLEXPRESS;Initial Catalog=SimpleCodeTwo;Integrated Security=True")
        {

        }

    }
}

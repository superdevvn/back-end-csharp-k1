using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Others
{
    public class DbUtils : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbUtils() : base("Data Source=(local);Initial Catalog=NewDatabaseBackEndC#;Integrated Security=True") {

        }

    }

  
}

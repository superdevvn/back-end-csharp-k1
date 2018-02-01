using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Others
{
    public class DBUtils : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DBUtils() : base("Data Source=DESKTOP-RB5AHK0;Initial Catalog=ProductEntity;Persist Security Info=True;User ID=sa;Password=1")
        {

        }


    }
}

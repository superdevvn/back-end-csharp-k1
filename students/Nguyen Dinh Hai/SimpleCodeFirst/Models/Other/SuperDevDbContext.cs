using System.Data.Entity;

namespace Models.Other
{
    public class SuperDevDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Product> Products { get; set; }
        public SuperDevDbContext()
            :base("Data Source=DESKTOP-15KKVN2\\SQLEXPRESS;Initial Catalog=SimpleCodeFirst;Integrated Security=True")
        {

        }
    }
}

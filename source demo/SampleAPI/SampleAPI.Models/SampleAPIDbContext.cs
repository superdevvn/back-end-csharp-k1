using System.Data.Entity;

namespace SampleAPI.Models
{
    public class SampleAPIDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public SampleAPIDbContext()
            :base("Data Source=DESKTOP-15KKVN2\\SQLEXPRESS;Initial Catalog=SampleAPI;Integrated Security=True;Persist Security Info=True")
        {

        }
    }
}

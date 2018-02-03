using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

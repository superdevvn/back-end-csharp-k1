using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Models
{
    public class SampleAPIDBContext: DbContext
    {
        public DbSet<USer> Users { get; set; }
        public SampleAPIDBContext()
            :base("Data Source=THINHPHSE62039\\SQLEXPRESS;Initial Catalog=SimpleAPI;Integrated Security=True")
        {

        }
    }
}

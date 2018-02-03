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
        public DbSet<User> Users { get; set; }
        public SampleAPIDBContext() : base("Data Source=SONNCSE62729;Initial Catalog=SampleAPI;Integrated Security=True")
        {

        }
    }
}

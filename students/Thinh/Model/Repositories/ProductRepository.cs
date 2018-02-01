using Model;
using Model.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository
    {
        public List<ProductComlex> GetList()
        {
            using (var context = new SuperDBContext())
        }
    }
}

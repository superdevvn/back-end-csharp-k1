using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using SamplePaging.Models;

namespace SamplePaging.Repositories
{
    public class DemoRepository
    {
        public PagedListResult<Demo> GetList(string whereClause, int pageSize, int pageNumber, string orderBy, string orderDirection)
        {
            using (var context = new SuperDevDbContext())
            {

                var query = context.Demos
                    .Where(whereClause)
                    .OrderBy(string.Format("{0} {1}", orderBy.Trim(), orderDirection.Trim()))
                    .ToPagedList(pageNumber, pageSize);
                return new PagedListResult<Demo>(query);
            }
        }
    }
}

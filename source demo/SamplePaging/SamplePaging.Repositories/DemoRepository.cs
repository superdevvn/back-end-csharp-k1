using System.Linq;
using System.Linq.Dynamic;
using PagedList;
using SamplePaging.Models;
using System.Data.Entity;

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

        public Demo GetById(int id)
        {
            using (var context = new SuperDevDbContext())
            {

                var a = context.Demos.Where(e => e.Id == id)
                    .Include(e=>e.Role)
                    .FirstOrDefault();
                a.Role.Demos = null;
                return a;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace SamplePaging.Repositories
{
    public class PagedListResult<T>
    {
        public int TotalItemCount { get; set; }
        public int TotalItemOnPage { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public List<T> Entities { get; set; }

        public PagedListResult(IPagedList<T> item)
        {
            TotalItemCount = item.TotalItemCount;
            TotalItemOnPage = item.Count;
            PageCount = item.PageCount;
            PageNumber = item.PageNumber;
            Entities = item.ToList();
        }
    }
}

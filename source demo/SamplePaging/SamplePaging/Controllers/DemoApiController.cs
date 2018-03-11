using System.Web.Http;
using SamplePaging.Repositories;

namespace SamplePaging.Controllers
{
    public class DemoApiController : ApiController
    {
        [HttpGet]
        [Route("api/getListDemo")]
        public IHttpActionResult GetListDemo(int pageSize, int pageNumber, string orderBy, string orderDirection, string code, string name)
        {
            string whereClause = "1>0";
            if (!string.IsNullOrWhiteSpace(code)) whereClause += string.Format(" AND Code.Contains(\"{0}\")", code);
            if (!string.IsNullOrWhiteSpace(name)) whereClause += string.Format(" AND Name.Contains(\"{0}\")", name);
            DemoRepository demoRepository = new DemoRepository();
            return Ok(demoRepository.GetList(whereClause, pageSize, pageNumber, orderBy, orderDirection));
        }

        [HttpGet]
        [Route("api/getDemo/{id}")]
        public IHttpActionResult GetDemo(int id)
        {
            DemoRepository demoRepository = new DemoRepository();
            return Ok(demoRepository.GetById(id));
        }
    }
}
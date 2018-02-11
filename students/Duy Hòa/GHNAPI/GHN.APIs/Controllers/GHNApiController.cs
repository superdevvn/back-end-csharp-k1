using GHN.Service;
using GHN.Service.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace GHN.APIs.Controllers
{
    [RoutePrefix("api")]
    public class GHNApiController : ApiController
    {

        [Route("getHubs")]
        [HttpPost]
        public async Task<IHttpActionResult> GetHubs()
        {
            var service = new GHNService();
            var result = await service.GetHubs();
            return Ok(result);
        }

        [Route("getDistricts")]
        [HttpPost]
        public async Task<IHttpActionResult> GetDistricts()
        {
            var service = new GHNService();
            var result = await service.GetDistricts();
            return Ok(result);
        }

        [Route("createOrder")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateOrder(ShippingOrder so)
        {
            var service = new GHNService();
            var result = await service.CreateOrder(so);
            return Ok(result);
        }
    }
}

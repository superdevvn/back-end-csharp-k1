using Models;
using Repositories;
using System.Web.Http;

namespace SampleAPI
{
    public class UserApiController : ApiController
    {
        [HttpPost]
        [Route("api/createUser")]
        public IHttpActionResult CreateUser(User user)
        {
            var userRepository = new UserRepository();
            return Ok(userRepository.Create(user));
        }
    }
}

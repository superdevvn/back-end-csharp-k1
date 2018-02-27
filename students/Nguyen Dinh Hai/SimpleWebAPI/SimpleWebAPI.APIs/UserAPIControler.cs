using SimpleAPI.Models;
using SimpleWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleWebAPI.APIs
{
    public class UserApiController : ApiController
    {
        [HttpPost ]
        [Route ("api/createUser")]
        public IHttpActionResult CreateUser(User user)
        {
            var userRepository = new UserRepository();
            return Ok(userRepository.Create(user));
        }
    }
}

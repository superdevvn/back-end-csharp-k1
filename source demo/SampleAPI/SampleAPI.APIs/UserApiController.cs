using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using SampleAPI.Models;
using SampleAPI.Repositories;

namespace SampleAPI.APIs
{
    public class UserApiController:ApiController
    {
        [HttpPost]
        [Route("api/createUser")]
        public IHttpActionResult CreateUser(User user)
        {
            var userRepository = new UserRepository();
            return Ok(userRepository.Create(user));
        }

        [HttpGet]
        [Route("api/getUsers")]
        public IHttpActionResult GetUsers()
        {
            var userRepository = new UserRepository();
            return Ok(userRepository.GetUsers());
        }

        [HttpGet]
        [Route("api/getUser/{id}")]
        public IHttpActionResult GetUser(Guid id)
        {
            var userRepository = new UserRepository();
            return Ok(userRepository.GetUser(id));
        }

        [HttpPost]
        [Route("api/deleteUser")]
        public IHttpActionResult DeleteUser([FromUri]Guid id)
        {
            var userRepository = new UserRepository();
            return Ok(userRepository.GetUser(id));
        }
    }
}

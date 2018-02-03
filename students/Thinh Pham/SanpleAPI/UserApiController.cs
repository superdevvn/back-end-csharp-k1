using SampleAPI.Models;
using SampleAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SanpleAPI
{
    public class UserApiController: ApiController
    {
        [HttpPost]
        [Route("api/createUser")]
       
        public IHttpActionResult CreateUser(USer user)
        {
            var userRepository = new UserRepositories();
            return Ok(userRepository.Create(user));
        }
        [HttpGet]
        [Route("api/getUsers")]
        public IHttpActionResult GetUser(USer user)
        {
            var userReposity = new UserRepositories();
            return Ok(userReposity.GetUser());
        }
        [HttpGet]
        [Route("api/getUser/{id}")]
        public IHttpActionResult GetUserById(Guid id)
        {
            var userReposity = new UserRepositories();
            return Ok(userReposity.GetUserById(id));
        }
        [HttpPost]
        [Route("api/deleteUser")]
        public IHttpActionResult DeleteUser([FromUri]Guid id)
        {
            var userReposity = new UserRepositories();
            userReposity.Delete(id);
            return Ok();
        }
    }
}
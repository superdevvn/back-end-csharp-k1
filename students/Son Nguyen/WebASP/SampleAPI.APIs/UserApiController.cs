using SampleAPI.Models;
using SampleAPI.Responsiblities;
using System;
using System.Web.Http;

namespace SampleAPI.APIs
{
    public class UserApiController:ApiController
    {
        [HttpPost]
        [Route("api/createUser")]
        public IHttpActionResult CreatorUser(User user)
        {
            var userResponsiblit = new UserResponsiblity();
            return Ok(userResponsiblit.Create(user));

        }
        [HttpGet]
        [Route("api/getUsers")]
        public IHttpActionResult getUsers(User user)
        {
            var userResponsiblit = new UserResponsiblity();
            return Ok();

        }
        [HttpGet]
        [Route("api/getUsers{id}")]
        public IHttpActionResult getUsers(Guid id)
        {
            var userResponsiblit = new UserResponsiblity();
            return Ok(userResponsiblit.GetById(id));

        }
        [HttpPost]
        [Route("api/deleteUser")]
        public IHttpActionResult deleteUser([FromUri]Guid id)
        {
            var userResponsiblit = new UserResponsiblity();
            return Ok(userResponsiblit.GetById(id));

        }
    }
}

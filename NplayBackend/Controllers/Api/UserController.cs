using Microsoft.AspNetCore.Mvc;
using NplayBackend.Models.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NplayBackend.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    { 
        [HttpGet]
        public ActionResult<UserDataDto> GetUser()
        {
            //check if user is authenticated, then return user info
            // make a null check for user
                

            if(User.Identity.IsAuthenticated)
            {
                return new UserDataDto
                {
                    UserName = User.Identity.Name,
                    Email = "test@Email",
                    UserId = "1234"
                };
            }
            else
            {
                return Unauthorized();
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using backend.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    firstName = "eiad",
                    lastName = "suliman",
                    userName = "eiadss",
                    email = "eiad@gmail.com",
                    password = "eiad12345",
                }
        };
            return Ok(users);
        }
    }
}

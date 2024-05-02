using backend.Data;
using backend.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _context.User.ToListAsync();

            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user is null)
                return NotFound("user not found");
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            var updatedUser = await _context.User.FindAsync(user.Id);
            if (updatedUser is null)
                return NotFound("user not found");
            updatedUser.firstName = user.firstName;
            updatedUser.lastName = user.lastName;
            updatedUser.email = user.email;
            updatedUser.password= user.password;
            updatedUser.userName = user.userName;
            updatedUser.firstName = user.firstName;
            await _context.SaveChangesAsync();
            return Ok(updatedUser);
        }
        [HttpDelete]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user is null)
                return NotFound("user not found");
             _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
    }
}

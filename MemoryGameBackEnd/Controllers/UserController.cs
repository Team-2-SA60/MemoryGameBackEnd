
using Microsoft.AspNetCore.Mvc;
using MemoryGameBackEnd.Models;
using MemoryGameBackEnd.data;
using MemoryGameBackEnd.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace MemoryGameBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MemoryGameBackEndContext _context;

        public UserController(MemoryGameBackEndContext context)
        {
            _context = context;
        }
        
        // POST: api/User/login
        // For login activity
        [HttpPost]
        [Route("login")]
        public ActionResult<UserResponseDto> Login(UserRequestDto userRequestDto)
        {
            var username = userRequestDto.Username;
            var password = userRequestDto.Password;

            if (username.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                return BadRequest("Username or password is empty");
            }
            
            if (!UserExists(username!))
            {
                return NotFound("Username not found");
            }
            
            User? user = _context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }
            
            return Ok(new UserResponseDto(user));
        }
        
        // GET: api/User/list
        // For testing purpose, get list of all users in database
        [HttpGet]
        [Route("list")]
        public ActionResult<List<User>> GetUsers()
        {
            return _context.Users.ToList();
        }

        private bool UserExists(string username)
        {
            return _context.Users.Any(e => e.Username == username);
        }
    }
}

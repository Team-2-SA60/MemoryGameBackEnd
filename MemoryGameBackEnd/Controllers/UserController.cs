using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MemoryGameBackEnd.Models;
using MemoryGameBackEnd.data;

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
        public ActionResult<UserDto> Login(string username, string password)
        {
            if (!UserExists(username))
            {
                return NotFound();
            }
            
            var user = _context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
            {
                return Unauthorized();
            }
            
            return Ok(new UserDto(user));
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

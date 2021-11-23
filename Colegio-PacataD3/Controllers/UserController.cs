using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Colegio_PacataD3.Data;
using Colegio_PacataD3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colegio_PacataD3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }
        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _repository.GetUsers();
        }
        // GET: api/User/2
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var users = await _repository.GetUser(id);

            if (users == null)
            {
                return NotFound();
            }
            return users;
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, [FromForm] User user)
        {

            var resp = _repository.PutUser(id,user);
            return Ok(resp);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromForm] User user)
        {
            _repository.PostUser(user);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var resp = _repository.DeleteUser(id);
            if (resp!=null)
            {
                return StatusCode(201);
            }
            else
            {
                return NotFound();
            }
        }





    }
}
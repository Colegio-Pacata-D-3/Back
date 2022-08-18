using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Colegio_PacataD3.Data;
using Colegio_PacataD3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Colegio_PacataD3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
            
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.Select(x => new User()
            {
                Id = x.Id,
                Ci= x.Ci,
                Name = x.Name,
                LastName = x.LastName,
                Email = x.Email,
                Birth = x.Birth,
                Password = x.Password,
                Course = x.Course,
                Rol = x.Rol,
                NumberReference = x.NumberReference
            }).ToListAsync();
        }
        [HttpGet("{grade}/estudiante")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersByGrade(int grade)
        {
            string n1= Convert.ToString(grade);
            return await _context.Users.Select(x => new User()
            {
                Id = x.Id,
                Ci = x.Ci,
                Name = x.Name,
                LastName = x.LastName,
                Email = x.Email,
                Birth = x.Birth,
                Password = x.Password,
                Course = x.Course,
                Rol = x.Rol,
                NumberReference = x.NumberReference
            }).Where(x => x.Course.Contains(n1) && x.Rol.Contains("estudiante")).ToListAsync();
        }


        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var UserModel = await _context.Users.FindAsync(id);

            if (UserModel == null)
            {
                return NotFound();
            }

            return UserModel;
        }


        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserModel(int id, User UserModel)
        {
            if (id != UserModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(UserModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<User>> PostUserModel(User UserModel)
        {
            _context.Users.Add(UserModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserModel", new { id = UserModel.Id }, UserModel);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUserModel(int id)
        {
            var UserModel = await _context.Users.FindAsync(id);
            if (UserModel == null)
            {
                return NotFound();
            }

            _context.Users.Remove(UserModel);
            await _context.SaveChangesAsync();

            return UserModel;
        }

        private bool UserModelExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
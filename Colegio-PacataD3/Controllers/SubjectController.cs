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
    public class SubjectController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly IUserRepository _repository;

        public SubjectController(IUserRepository repository, UserContext context)
        {
            _repository = repository;
            _context = context;

        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            return await _context.Subjects.Select(x => new Subject()
            {
                Id = x.Id,
                IdTeacher = x.IdTeacher,
                Name = x.Name,
                Grade = x.Grade
            }).ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            var SubjectModel = await _context.Subjects.FindAsync(id);

            if (SubjectModel == null)
            {
                return NotFound();
            }

            return SubjectModel;
        }


        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectModel(int id, Subject SubjectModel)
        {
            if (id != SubjectModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(SubjectModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectModelExists(id))
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
        public IActionResult PostSubjectModel(Subject x)
        {
            var Subject = new Subject
            {
                Id = x.Id,
                IdTeacher= x.IdTeacher,
                Name = x.Name,
                Grade = x.Grade
            };
            return Created("success", _repository.CreateSubject(Subject));
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subject>> DeleteSubjectModel(int id)
        {
            var SubjectModel = await _context.Subjects.FindAsync(id);
            if (SubjectModel == null)
            {
                return NotFound();
            }

            _context.Subjects.Remove(SubjectModel);
            await _context.SaveChangesAsync();

            return SubjectModel;
        }

        private bool SubjectModelExists(int id)
        {
            return _context.Subjects.Any(e => e.Id == id);
        }
    }
}

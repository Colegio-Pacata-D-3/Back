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
    public class NoteController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly IUserRepository _repository;

        public NoteController(IUserRepository repository,UserContext context)
        {
            _repository = repository;
            _context = context;

        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            return await _context.Notes.Select(x => new Note()
            {
                Id = x.Id,
                IdEst = x.IdEst,
                Area = x.Area,
                Grade = x.Grade,
                Trimester = x.Trimester,
                Ser = x.Ser,
                Saber1 = x.Saber1,
                Saber2 = x.Saber2,
                Saber3 = x.Saber3,
                Saber4 = x.Saber4,
                Hacer1 = x.Hacer1,
                Hacer2 = x.Hacer2,
                Hacer3 = x.Hacer3,
                Hacer4 = x.Hacer4,
                Decidir = x.Decidir,
                SerE = x.SerE,
                DecidirE = x.DecidirE
            }).ToListAsync();
            
        }
        [HttpGet("{grade}/{trimester}/{subject}")]
        public async Task<ActionResult<IEnumerable<NoteStudent>>> GetNotesByGrade(int grade,int trimester, string subject)
        {

             var lista = await _context.Notes.Select(x => new NoteStudent()
            {
                Id = x.Id,
                IdEst = x.IdEst,
                Area = x.Area,
                Grade = x.Grade,
                Trimester = x.Trimester,
                Ser = x.Ser,
                Saber1 = x.Saber1,
                Saber2 = x.Saber2,
                Saber3 = x.Saber3,
                Saber4 = x.Saber4,
                Hacer1 = x.Hacer1,
                Hacer2 = x.Hacer2,
                Hacer3 = x.Hacer3,
                Hacer4 = x.Hacer4,
                Decidir = x.Decidir,
                SerE = x.SerE,
                DecidirE = x.DecidirE
            }).Where(x => x.Area.Contains(subject)&&x.Trimester==trimester&&x.Grade==grade).ToListAsync();
            for (int i = 0; i < lista.Count; i++)
            {
                User student = await _context.Users.FindAsync(lista[i].IdEst);
                lista[i].Name = student.Name;
                lista[i].LastName = student.LastName;
            }
            return lista;
        }
        [HttpGet("{id}/{trimester}")]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotesByStudent(int id, int trimester)
        {

            var lista = await _context.Notes.Select(x => new Note()
            {
                Id = x.Id,
                IdEst = x.IdEst,
                Area = x.Area,
                Grade = x.Grade,
                Trimester = x.Trimester,
                Ser = x.Ser,
                Saber1 = x.Saber1,
                Saber2 = x.Saber2,
                Saber3 = x.Saber3,
                Saber4 = x.Saber4,
                Hacer1 = x.Hacer1,
                Hacer2 = x.Hacer2,
                Hacer3 = x.Hacer3,
                Hacer4 = x.Hacer4,
                Decidir = x.Decidir,
                SerE = x.SerE,
                DecidirE = x.DecidirE
            }).Where(x => x.IdEst == id && x.Trimester == trimester).ToListAsync();
            return lista;
        }


        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            var NoteModel = await _context.Notes.FindAsync(id);

            if (NoteModel == null)
            {
                return NotFound();
            }

            return NoteModel;
        }


        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoteModel(int id, Note NoteModel)
        {
            if (id != NoteModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(NoteModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteModelExists(id))
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
        public IActionResult PostNoteModel(Note x)
        {
            var note = new Note
            {
                Id=x.Id,
                IdEst = x.IdEst,
                Area = x.Area,
                Grade = x.Grade,
                Trimester = x.Trimester,
                Ser = x.Ser,
                Saber1 = x.Saber1,
                Saber2 = x.Saber2,
                Saber3 = x.Saber3,
                Saber4 = x.Saber4,
                Hacer1 = x.Hacer1,
                Hacer2 = x.Hacer2,
                Hacer3 = x.Hacer3,
                Hacer4 = x.Hacer4,
                Decidir = x.Decidir,
                SerE = x.SerE,
                DecidirE = x.DecidirE
            };
            return Created("success", _repository.CreateNote(note));
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Note>> DeleteNoteModel(int id)
        {
            var NoteModel = await _context.Notes.FindAsync(id);
            if (NoteModel == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(NoteModel);
            await _context.SaveChangesAsync();

            return NoteModel;
        }

        private bool NoteModelExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
    }
}

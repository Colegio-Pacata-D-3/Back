using Colegio_PacataD3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio_PacataD3.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            Note n1 = new Note();
            n1.IdEst = user.Id;
            n1.Grade = Int32.Parse(user.Course);
            string[] materias;
            string[] materias2;
            materias = new string[13] { "Lenguaje", "Lengua extranjera", "Ciencias sociales","Educacion fisica", "Educacion Musical","Artes plasticas", "Computacion", "Matematicas","Ciencias naturales", "Fisica", "Quimica", "Filosofia", "Religion"  };
            materias2 = new string[13] { "Lenguaje", "Lengua extranjera", "Ciencias sociales", "Educacion fisica", "Educacion Musical", "Artes plasticas", "Computacion", "Matematicas", "Ciencias naturales", "Fisica", "Quimica", "Filosofia", "Religion" };
            
            if (user.Rol.CompareTo("estudiante")==0)
            {
                if (Int32.Parse(user.Course) <=2)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        n1.Trimester = j + 1;
                        for (int i = 0; i < 13; i++)
                        {
                            n1.Area = materias2[i];
                            n1.Id = 0;
                            CreateNote(n1);
                        }

                    }
                   
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                    {
                        n1.Trimester = j + 1;
                        for (int i = 0; i < 13; i++)
                        {
                            n1.Area = materias[i];
                            CreateNote(n1);
                        }
                    }
                    
                }
            }

            return user;
        }
        public Note CreateNote(Note note)
        {
            _context.Notes.Add(note);
            note.Id = _context.SaveChanges();
            return note;
        }
        public Subject CreateSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            subject.Id = _context.SaveChanges();
            return subject;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.Select(x => new User()
            {
                Id = x.Id,
                Ci= x.Ci,
                Name = x.Name,
                Email = x.Email,
                Password = x.Password,
                Course = x.Course,
                Rol = x.Rol,
                NumberReference = x.NumberReference

            }).ToListAsync();
        }
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public User PutUser(int id, User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return user;    
        }
        public User PostUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        public User DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return null;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }
    }
}

using Colegio_PacataD3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio_PacataD3.Data
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(int id);
        Task<ActionResult<IEnumerable<User>>> GetUsers();
        Task<ActionResult<User>> GetUser(int id);

        User PutUser(int id, User user);
        User PostUser(User user);
        User DeleteUser(int id);

    }
}

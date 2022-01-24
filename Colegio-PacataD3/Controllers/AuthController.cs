using Colegio_PacataD3.Data;
using Colegio_PacataD3.Dto;
using Colegio_PacataD3.Helpers;
using Colegio_PacataD3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio_PacataD3.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController : Controller
    {   

        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Birth = dto.Birth,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                NumberReference = dto.NumberReference
            };
            return Created("success", _repository.Create(user));
        } 

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);
            if (user == null) return BadRequest(new { message = "Credenciales invalidos" });
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message = "Credenciales invalidos" });
            }
            var jwt = _jwtService.Generate(user.Id);
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok(new{
                message = "success",
                name= user.Name,
                email=user.Email
                });
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                var user = _repository.GetById(userId);
                return Ok(user);
            }
            catch (Exception)
            {

                return Unauthorized();
            }
            
               

        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {

            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                message = "Logout success"
            });

        }

    }
}

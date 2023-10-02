using Aloha_Academy_Graduate_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Aloha_Academy_Graduate_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly SqlContext _contex;

        public RegisterController() 
        {
            _contex = new SqlContext();
        }


        [HttpPost("register")]
        public IActionResult PostRegister( Register register)
        {
            if(_contex.Registers.Any(r => r.Email == register.Email))
            {
                return BadRequest("Mail adresine kayıtlı kullanıcı mevcuttur!");
            }
            Register newregister = new Register();
            newregister.Birthdate = register.Birthdate;
            newregister.RePassword = register.RePassword.ToString();
            newregister.Email = register.Email;
            newregister.Fullname = register.Fullname;
            newregister.Password = register.Password.ToString();
            newregister.Phone = register.Phone;


            if(newregister == null )
            {
                return NotFound();
            }
            else
            {
                _contex.Registers.Add(newregister);
                _contex.SaveChanges();
                return Ok(newregister);
            }
           
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            var user = await _contex.Registers.Where(p => p.Password == userLogin.Password ).FirstOrDefaultAsync();
            var userPassword = await _contex.Registers.Where(u => u.Email == userLogin.Email).FirstOrDefaultAsync();

            if (user == null || userPassword == null)
            {
                return BadRequest("Kullanıcı bulunamadı");
            }
           
            return Ok($"hoşgeldiniz {userLogin.Email}");

        }
    }
}

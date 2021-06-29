using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Business.Abstract;
using StudentInformationSystem.Data.DTOS;

namespace StudentInformationSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]  UserDto userForLoginDto)
        {
            var userToLogin = _userService.Login(userForLoginDto);
            if (userToLogin==null)
            {
                return Unauthorized();
            }

            return Ok("Login başarılı");
            

        }
        

        [HttpPost("Register")]
        public IActionResult Register([FromBody]  UserDto userForRegisterDto)
        {
            var userExists = _userService.UserExists(userForRegisterDto.Email);
            if (!userExists)
            {
                return BadRequest("Kullanıcı mevcut");
            }

            var registerResult = _userService.Register(userForRegisterDto);
            if (registerResult!=null)
            {
                return Ok();
            }

            return BadRequest("Kayıt olunamadı.");
        }
    }
}

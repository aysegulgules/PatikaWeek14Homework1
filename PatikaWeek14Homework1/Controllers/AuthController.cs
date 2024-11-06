using PatikaWeek14Homework1.User;
using PatikaWeek14Homework1.User.Dtos;
//using PatikaWeek14Homework1.Jwt;
using PatikaWeek14Homework1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaWeek14Homework1.Models;

namespace PatikaWeek14Homework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if(!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }

            var addUserDto = new AddUserDto()
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password,           

            };
            var result= await _userService.AddUser(addUserDto);

            if(result.IsSucceed)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
            
        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _userService.LoginUser(
               new LoginUserDto
                {
                    Email = loginRequest.Email,
                   Password = loginRequest.Password,
               }
               );

            if(!result.IsSucceed)
            {
                return BadRequest(result.Message);

           }

        //    var user = result.Data;

        //    var configuration=HttpContext.RequestServices.GetRequiredService<IConfiguration>();

        //    var token = JwtHelper.GenerateJwtToken(new JwtDto
        //    {
        //        Id = user.Id,
        //        Email = user.Email,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        UserType = user.UserType,
        //        SecretKey = configuration["Jwt:SecretKey"]!,
        //        Issuer = configuration["Jwt:Issuer"]!,
        //        Audience = configuration["Jwt:Audience"]!,
        //        ExpireMinutes = int.Parse(configuration["Jwt:ExpireMinutes"]!),

        //    }
        //    );


        //    return Ok( new LoginResponse
        //    {
        //        Message="Giriş başarı ile gerçekleşti",
        //        Token = token,
        //    });
        }



    }
}

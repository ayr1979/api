using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using DatingApp.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper 
        ,UserManager<User> userManager, SignInManager<User> signInManager   )
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            _mapper = mapper;
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(User user)
        {

           // user.UserName = user.CompanyName;

            //var userToCreate = _mapper.Map<User>(user);

            try
            { 
            var result = await _userManager.CreateAsync(user, user.Password);
            
            //var userToReturn = _mapper.Map<UserForDetailedDto>(userToCreate);

            if (result.Succeeded)
            {
                return CreatedAtRoute("GetUser", new { controller = "Users", id = user.Id }, user);
            }

            return BadRequest("Failed to Register");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userForLoginDto.Username);
          
            var result = await _signInManager.CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

            if (result.Succeeded)
            {
                var appUser = _mapper.Map<UserForListDto>(user);


                return Ok(new
                {
                    token = GenerateJwtToken(user),
                    user = appUser
                });
            }

            }
            catch (Exception e)
            { }
            return Unauthorized();

            

            
        }
    

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.CompanyName)
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_config.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
}
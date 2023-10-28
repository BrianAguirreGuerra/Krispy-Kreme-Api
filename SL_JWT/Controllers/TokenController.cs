using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SL_JWT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody] ML.User login)
        {
            if (login == null) return Unauthorized();
            string tokenString = string.Empty;
            bool validUser = Authenticate(login);
            if (validUser)
            {
                BL.Token token = new BL.Token(_configuration);
                tokenString = token.BuildJWTToken();
            }
            else
            {
                return Unauthorized();
            }
            return Ok(new { Token = tokenString });
        }
        private bool Authenticate(ML.User login)
        {
            bool validUser = false;

            if (login.Email == _configuration["AuthLogin:UserName"] && login.Password == _configuration["AuthLogin:Password"])
            {
                validUser = true;
            }
            return validUser;
        }
    }
}
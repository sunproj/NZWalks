using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repo;

namespace NZWalks.API.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepo iUserRepo;
        private readonly ITokenhandler itokenhandler;

        public AuthController(IUserRepo _iUserRepo, ITokenhandler _itokenhandler)
        {
            iUserRepo = _iUserRepo;
            itokenhandler = _itokenhandler;
        }



        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> ValidateLogin(LoginRequest _LoginRequest)
        {
            // Validate the request


            var _user = await iUserRepo.AuthenticateAsync(_LoginRequest.Username, _LoginRequest.Password);

            if (_user !=null)
            {
                // Generrate the JWT token and return
                var token = await itokenhandler.CreatTokenAsync(_user);
                return Ok(token);
            }

            // return a Bad Request
            return BadRequest("Username & Password is Incorrect");

        }
    }
}

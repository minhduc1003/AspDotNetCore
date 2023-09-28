using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using test.Models.Dto;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public RegisterController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost]
        
        public async Task<IActionResult> Register([FromBody] RegisterReqDto registerReqDto)
        {
            var idenityUser = new IdentityUser()
            {
                Email = registerReqDto.EmailAddress,
                UserName = registerReqDto.EmailAddress
            };
            var identityResult = await userManager.CreateAsync(idenityUser, registerReqDto.Password);
            if(identityResult.Succeeded)
            {
                /* if(registerReqDto.Role != null&& registerReqDto.Role.Any())
                  {
                      identityResult = await userManager.AddToRolesAsync(idenityUser, registerReqDto.Role);
                      if(identityResult.Succeeded)
                      {
                          return Ok("User was regitered successfully,pls login");
                      }
                  }*/
                return Ok("User was regitered successfully,pls login");
            }
            return BadRequest("Something was wrong");
        }
    }
}

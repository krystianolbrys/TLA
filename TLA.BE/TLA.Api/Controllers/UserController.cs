using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TLA.Api.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        // temporary
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Hash, model.Login),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

            return Ok();
        }

        // temporary
        [Authorize]
        [HttpPost]
        [Route("readLogin")]
        public async Task<ActionResult> ReadLogin()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Hash))!.Value;
            return Ok(userId);
        }
    }

    // temporary
    public class LoginViewModel
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

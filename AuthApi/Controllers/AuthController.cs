using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi;

[ApiController]
[Route("api/[controller]")]
public class AuthController(SignInManager<ApplicationUser> _signInManager) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
    {
        if (string.IsNullOrEmpty(loginRequestDTO.Email) || string.IsNullOrEmpty(loginRequestDTO.Password))
        {
            return Unauthorized();
        }

        var result = await _signInManager.PasswordSignInAsync(loginRequestDTO.Email, loginRequestDTO.Password, false, false);

        if (result.Succeeded)
        {
            var token = new TokenJwtBuilder()
            .AddSecurityKey(JwtSecurityKey.Create("superSecretKey@345"))
            .AddSubject("App.Security")
            .AddIssuer("App.Security")
            .AddAudience("App.Security")
            .AddClaim("email", loginRequestDTO.Email)
            .AddExpiresInMinutes(5)
            .Build();

            return Ok(token.Value);
        }

        return Unauthorized();
    }
}

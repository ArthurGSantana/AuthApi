using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi;

[ApiController]
[Route("api/[controller]")]
public class UserController(UserManager<ApplicationUser> _userManager) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRequestDTO userRequestDTO)
    {
        if (string.IsNullOrEmpty(userRequestDTO.Email) || string.IsNullOrEmpty(userRequestDTO.Password) || string.IsNullOrEmpty(userRequestDTO.RG))
        {
            return BadRequest();
        }

        var user = new ApplicationUser
        {
            UserName = userRequestDTO.Email,
            Email = userRequestDTO.Email,
            RG = userRequestDTO.RG
        };

        var result = await _userManager.CreateAsync(user, userRequestDTO.Password);

        if (result.Succeeded)
        {
            return Ok("Usuário criado com sucesso");
        }

        return BadRequest();
    }
}

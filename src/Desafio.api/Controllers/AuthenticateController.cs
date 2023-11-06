using Desafio.Application;
using Desafio.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.api.Controllers;

[ApiController]
[Route("api/auth")]
    
public class AuthenticateController : ControllerBase
{
    private readonly IAuthAppService _authService;

    public AuthenticateController(IAuthAppService authAppService)
    {
        this._authService = authAppService;
    }

    [HttpPost]
    public async Task<ActionResult> Authenticate([FromBody] UserDto LoginModel)
    {
        if (LoginModel == null)
            return BadRequest();

        var result = await _authService.Authenticate<UserValidator>(LoginModel);

        if (!result.ValidationResult.IsValid)
            return BadRequest(result.ValidationResult.ToString(Environment.NewLine));

        return Ok(result.Data.Token);
    }
}


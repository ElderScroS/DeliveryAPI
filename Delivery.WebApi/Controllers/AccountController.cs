using Delivery.Core.DTO;
using Delivery.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterUserDto request)
    {
        var result = await _accountService.RegisterAsync(request);

        if (result.Succeeded)
        {
            return Ok("Account registered!");
        }

        return BadRequest();
    }
        
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginUserDto request)
    {
        var result = await _accountService.LoginAsync(request);

        if (result != null)
        {
            return Ok(result);
        }

        return BadRequest();
    }

    [HttpGet("logout")]
    public async Task<ActionResult> LogOut()
    {
        await _accountService.LogOutAsync();
        
        return NoContent();
    }
    
    [HttpPost("refresh")]
    public async Task<ActionResult> Refresh([FromBody] RefreshJwtDto request)
    {
        var result = await _accountService.RefreshAsync(request);

        return Ok(result);
    }
}

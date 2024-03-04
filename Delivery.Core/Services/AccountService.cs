using System.Security.Claims;
using Delivery.Core.Domain.IdentityEntities;
using Delivery.Core.DTO;
using Delivery.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Delivery.Core.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtService _jwtService;
    
    public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtService jwtService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtService = jwtService;
    }
    
    public async Task<IdentityResult> RegisterAsync(RegisterUserDto request)
    {
        ApplicationUser user = new ApplicationUser()
        {
            Email = request.Email,
            UserName = request.Email,
            Name = request.Name,
        };
        
        IdentityResult result = await _userManager.CreateAsync(user, request.Password);

        return result;
    }
    
    public async Task<AuthenticationResponseDto?> LoginAsync(LoginUserDto request)
    {
        SignInResult result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, isPersistent: false, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return null;
            }
            
            await _signInManager.SignInAsync(user, isPersistent: false);
            var response = await _jwtService.GenerateSecurityTokenAsync(user);
            user.RefreshToken = response.RefreshToken;
            user.RefreshTokenExpiration = response.RefreshTokenExpiration;
            await _userManager.UpdateAsync(user);

            return response;
        }
        
        return null;
    }

    public async Task<AuthenticationResponseDto> RefreshAsync(RefreshJwtDto request)
    {
        ClaimsPrincipal principal = _jwtService.GetPrincipalFromJwtToken(request.JwtToken);

        if (principal == null)
        {
            throw new SecurityTokenException("Invalid JWT token");
        }

        string email = principal.FindFirstValue(ClaimTypes.Email);
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiration <= DateTime.Now)
        {
            throw new SecurityTokenException("Invalid refresh token");
        }

        var response = await _jwtService.GenerateSecurityTokenAsync(user);
        user.RefreshToken = response.RefreshToken;
        user.RefreshTokenExpiration = response.RefreshTokenExpiration;

        await _userManager.UpdateAsync(user);

        return response;
    }

    public async Task LogOutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Delivery.Core.Domain.IdentityEntities;
using Delivery.Core.DTO;
using Delivery.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Delivery.Core.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _jwtConfig;
    private readonly UserManager<ApplicationUser> _userManager;
    
    public JwtService(IConfiguration jwtConfig, UserManager<ApplicationUser> userManager)
    {
        _jwtConfig = jwtConfig;
        _userManager = userManager;
    }

    public async Task<AuthenticationResponseDto> GenerateSecurityTokenAsync(ApplicationUser user)
    {
        DateTime expiration = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_jwtConfig["JWT:Expiration"]));
        var role = await _userManager.GetRolesAsync(user);
        
        Claim[] claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };
        
        var possibleClaims = await _userManager.GetClaimsAsync(user);
        await _userManager.RemoveClaimsAsync(user, possibleClaims);
        await _userManager.AddClaimsAsync(user, claims);
        
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig["JWT:Secret"]));
        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            _jwtConfig["JWT:Issuer"],
            _jwtConfig["JWT:Audience"],
            claims,
            expires: expiration,
            signingCredentials: signingCredentials
            );

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        string response = tokenHandler.WriteToken(token);

        return new AuthenticationResponseDto()
        {
            Email = user.Email,
            Name = user.Name,
            Jwt = response,
            JwtExpiration = expiration,
            RefreshToken = GenerateRefreshToken(),
            RefreshTokenExpiration = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_jwtConfig["RefreshToken:Expiration"])),
        };
    }
    
    public ClaimsPrincipal? GetPrincipalFromJwtToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig["JWT:Secret"])),
            ValidIssuer = _jwtConfig["JWT:Issuer"],
            ValidAudience = _jwtConfig["JWT:Audience"],
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is JwtSecurityToken jwtSecurityToken && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return principal;
            }
            
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    private static string GenerateRefreshToken()
    {
        byte[] bytes = new byte[64];
        var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(bytes);
        
        return Convert.ToBase64String(bytes);
    }
}
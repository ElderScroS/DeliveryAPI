using System.Security.Claims;
using Delivery.Core.Domain.IdentityEntities;
using Delivery.Core.DTO;

namespace Delivery.Core.ServiceContracts;

public interface IJwtService
{
    Task<AuthenticationResponseDto> GenerateSecurityTokenAsync(ApplicationUser user);
    
    ClaimsPrincipal? GetPrincipalFromJwtToken(string token);
}
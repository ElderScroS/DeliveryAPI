using Delivery.Core.DTO;
using Microsoft.AspNetCore.Identity;

namespace Delivery.Core.ServiceContracts;

public interface IAccountService
{
    Task<IdentityResult> RegisterAsync(RegisterUserDto request);

    Task<AuthenticationResponseDto?> LoginAsync(LoginUserDto request);
    
    Task<AuthenticationResponseDto> RefreshAsync(RefreshJwtDto request);

    Task LogOutAsync();
}
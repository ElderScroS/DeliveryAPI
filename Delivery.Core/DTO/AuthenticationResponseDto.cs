namespace Delivery.Core.DTO;

public record AuthenticationResponseDto
{
    public string? Name { get; init; }
    
    public string? Email { get; init; }
    
    public string? Jwt { get; init; }
    
    public string? RefreshToken { get; init; }
    
    public DateTime RefreshTokenExpiration { get; init; }
    
    public DateTime JwtExpiration { get; set; }
}
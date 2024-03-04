namespace Delivery.Core.DTO;

public record RefreshJwtDto
{
    public string? JwtToken { get; init; }
    
    public string? RefreshToken { get; init; }
}
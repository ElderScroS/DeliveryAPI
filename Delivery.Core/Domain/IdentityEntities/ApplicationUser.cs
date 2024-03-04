using Delivery.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Delivery.Core.Domain.IdentityEntities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? Name { get; set; }
        
    public string? RefreshToken { get; set; }
    
    public DateTime RefreshTokenExpiration { get; set; }
    
    public List<Order>? OrderHistory { get; set; }
}
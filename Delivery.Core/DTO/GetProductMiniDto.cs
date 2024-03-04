using Delivery.Core.Domain.Entities;

namespace Delivery.Core.DTO;

public record GetProductMiniDto
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public decimal Price { get; init; }
    
    public ProductImageUrl ProductImageUrl { get; init; }
    
    public string Currency { get; init; }
    
    public string SellingType { get; init; }

    public string ProductType { get; init; }
}
using Delivery.Core.Domain.Entities;
using Type = System.Type;

namespace Delivery.Core.DTO;

public class GetProductDto
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public decimal Price { get; init; }

    public string CategoryName { get; init; }
    
    public string ManufactureCountry { get; init; }
    
    public List<ProductImageUrl> ImageUrls { get; init; }
    
    public string Currency { get; init; }
    
    public string SellingType { get; init; }
    
    public string Weight { get; init; }
    
    public string Description { get; init; }

    public string ProductTypeName { get; init; }
}
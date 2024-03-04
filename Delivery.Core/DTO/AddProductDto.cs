using Delivery.Core.Domain.Entities;

namespace Delivery.Core.DTO;

public record AddProductDto
{
    public string Name { get; set; }
    
    public decimal Price { get; set; }

    public Guid CategoryId { get; set; }
    
    public string ManufactureCountry { get; set; }
    
    public List<ProductImageUrl> ImageUrls { get; set; }
    
    public string Currency { get; set; }
    
    public string SellingType { get; set; }
    
    public string Weight { get; set; }
    
    public string Description { get; set; }

    public Guid ProductTypeId { get; set; }
}
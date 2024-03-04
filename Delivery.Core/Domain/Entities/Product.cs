using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Delivery.Core.Domain.Entities;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    [JsonIgnore]
    public Guid CategoryId { get; set; }

    [JsonIgnore]
    public Category? Category { get; set; }
    
    public string ManufactureCountry { get; set; }
    
    public List<ProductImageUrl> ImageUrls { get; set; }
    
    public string Currency { get; set; }
    
    public string SellingType { get; set; }
    
    [JsonIgnore]
    public List<Order>? Orders { get; set; }
    
    public string Weight { get; set; }
    
    public string Description { get; set; }
    
    [JsonIgnore]
    public Guid ProductTypeId { get; set; }

    public ProductType ProductType { get; set; }
}
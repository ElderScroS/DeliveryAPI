using System.Net.Mime;
using System.Text.Json.Serialization;
using Delivery.Core.Domain.Entities;

namespace Delivery.Core.DTO;

public record GetCategoryDto
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public Uri ImageUrl { get; set; }
    
    public List<Product> Products { get; set; }
    
    [JsonIgnore]
    public List<ProductType> ProductTypes { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Delivery.Core.Domain.Entities;

public class Category
{
    [Key]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public Uri ImageUrl { get; set; }
    
    [JsonIgnore]
    public List<Product>? Products { get; set; }
    
    [JsonIgnore]
    public List<ProductType>? ProductTypes { get; set; }
}
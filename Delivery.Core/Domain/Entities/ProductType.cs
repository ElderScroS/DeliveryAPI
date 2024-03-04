using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Delivery.Core.Domain.Entities;

public class ProductType
{
    [Key]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    [JsonIgnore]
    public List<Product>? Products { get; set; }
    
    [JsonIgnore]
    public Guid? CategoryId { get; set; }
    
    [JsonIgnore]
    public Category? Category { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Delivery.Core.Domain.Entities;

public class ProductImageUrl
{
    [Key]
    [JsonIgnore]
    public Guid Id { get; set; }
    
    public Uri Url { get; set; }
    
    [JsonIgnore]
    public Guid ProductId { get; set; }

    [JsonIgnore]
    public Product? Product { get; set; }
}
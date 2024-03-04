using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Delivery.Core.Domain.IdentityEntities;

namespace Delivery.Core.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    
    public DateTime OrdeDate { get; set; }
    
    public List<Product> Products { get; set; }
    
    [ForeignKey("ApplicationUserId")]
    [JsonIgnore]
    public Guid ApplicationUserId { get; set; }
    
    [JsonIgnore]
    public ApplicationUser? User { get; set; }
}
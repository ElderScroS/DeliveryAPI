using Delivery.Core.Domain.Entities;

namespace Delivery.Core.DTO;

public class GetCategoryMiniDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public Uri ImageUrl { get; set; }
    
    public int ProductsQuantity { get; set; }
}
namespace Delivery.Core.DTO;

public record AddProductTypeDto
{
    public string Name { get; init; }
    
    public Guid CategoryId { get; init; }
}
namespace Delivery.Core.DTO;

public record GetProductTypeDto
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public int ProductsQuantity { get; set; }
}
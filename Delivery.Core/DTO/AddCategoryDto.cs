namespace Delivery.Core.DTO;

public record AddCategoryDto
{
    public string Name { get; init; }
    
    public Uri ImageUrl { get; init; }
}
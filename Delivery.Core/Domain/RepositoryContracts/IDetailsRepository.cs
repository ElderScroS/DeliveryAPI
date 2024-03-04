using Delivery.Core.Domain.Entities;
using Delivery.Core.Domain.IdentityEntities;
using Delivery.Core.DTO;

namespace Delivery.Core.Domain.RepositoryContracts;

public interface IDetailsRepository
{
    Task<IEnumerable<GetCategoryMiniDto>> GetAllCategoriesFromDbAsync();
    
    Task<IEnumerable<GetProductTypeDto>> GetTypesByCategoryIdFromDbAsync(Guid categoryId);
    
    Task<IEnumerable<GetProductMiniDto>> GetAllProductsFromDbAsync();

    Task<GetProductDto> GetProductByIdFromDbAsync(Guid productId);

    Task<GetCategoryDto> GetProductsByCategoryIdFromDbAsync(Guid categoryId);

    Task<bool> ProcessOrderInDbAsync(ApplicationUser user, List<Product> products);

    Task<IEnumerable<Order>> GetOrdersHistoryFromDbAsync(ApplicationUser user);
}
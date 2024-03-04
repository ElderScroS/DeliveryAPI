using Delivery.Core.Domain.Entities;
using Delivery.Core.DTO;

namespace Delivery.Core.ServiceContracts;

public interface IDetailsService
{
    Task<IEnumerable<GetCategoryMiniDto>> GetAllCategoriesAsync();
    
    Task<IEnumerable<GetProductTypeDto>> GetTypesByCategoryIdAsync(Guid categoryId);
    
    Task<IEnumerable<GetProductMiniDto>> GetAllProductsAsync();

    Task<GetProductDto> GetProductByIdFromDbAsync(Guid productId);

    Task<GetCategoryDto> GetProductsByCategoryIdAsync(Guid categoryId);

    Task<bool> ProcessOrder(List<Product> products);

    Task<IEnumerable<Order>> GetOrdersHistory();
}
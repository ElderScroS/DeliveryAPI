using Delivery.Core.Domain.Entities;
using Delivery.Core.DTO;

namespace Delivery.Core.Domain.RepositoryContracts;

public interface IAdminRepository
{
    Task<ProductType> AddTypeToDbAsync(AddProductTypeDto request);

    Task<Category> AddCategoryToDbAsync(AddCategoryDto request);

    Task<Product> AddProductToDbAsync(AddProductDto request);
}
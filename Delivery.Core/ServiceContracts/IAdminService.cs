using Delivery.Core.Domain.Entities;
using Delivery.Core.DTO;

namespace Delivery.Core.ServiceContracts;

public interface IAdminService
{
    Task<ProductType> AddType(AddProductTypeDto request);

    Task<Category> AddCategory(AddCategoryDto request);

    Task<Product> AddProduct(AddProductDto request);
}
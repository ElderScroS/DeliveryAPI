using Delivery.Core.Domain.Entities;
using Delivery.Core.Domain.RepositoryContracts;
using Delivery.Core.DTO;
using Delivery.Core.ServiceContracts;

namespace Delivery.Core.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
    
    public async Task<ProductType> AddType(AddProductTypeDto request)
    {
        var result = await _adminRepository.AddTypeToDbAsync(request);

        return result;
    }

    public async Task<Category> AddCategory(AddCategoryDto request)
    {
        var result = await _adminRepository.AddCategoryToDbAsync(request);

        return result;
    }

    public async Task<Product> AddProduct(AddProductDto request)
    {
        var result = await _adminRepository.AddProductToDbAsync(request);

        return result;
    }
}
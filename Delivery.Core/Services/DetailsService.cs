using Delivery.Core.Domain.Entities;
using Delivery.Core.Domain.IdentityEntities;
using Delivery.Core.Domain.RepositoryContracts;
using Delivery.Core.DTO;
using Delivery.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Delivery.Core.Services;

public class DetailsService : IDetailsService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IDetailsRepository _detailsRepository;
    
    public DetailsService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor,
        IDetailsRepository detailsRepository)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _detailsRepository = detailsRepository;
    }
    
    public async Task<IEnumerable<GetCategoryMiniDto>> GetAllCategoriesAsync()
    {
        return await _detailsRepository.GetAllCategoriesFromDbAsync();
    }

    public async Task<IEnumerable<GetProductTypeDto>> GetTypesByCategoryIdAsync(Guid categoryId)
    {
        return await _detailsRepository.GetTypesByCategoryIdFromDbAsync(categoryId);
    }

    public async Task<IEnumerable<GetProductMiniDto>> GetAllProductsAsync()
    {
        return await _detailsRepository.GetAllProductsFromDbAsync();
    }

    public async Task<GetProductDto> GetProductByIdFromDbAsync(Guid productId)
    {
        return await _detailsRepository.GetProductByIdFromDbAsync(productId);
    }

    public async Task<GetCategoryDto> GetProductsByCategoryIdAsync(Guid categoryId)
    {
        return await _detailsRepository.GetProductsByCategoryIdFromDbAsync(categoryId);
    }

    public async Task<bool> ProcessOrder(List<Product> products)
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);

        if (user == null)
        {
            return false;
        }

        var result = await _detailsRepository.ProcessOrderInDbAsync(user, products);
        
        return result;
    }
    
    public async Task<IEnumerable<Order>> GetOrdersHistory()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        
        if (user == null)
        {
            throw new KeyNotFoundException();
        }

        var result = await _detailsRepository.GetOrdersHistoryFromDbAsync(user);
        
        return result;
    }
}
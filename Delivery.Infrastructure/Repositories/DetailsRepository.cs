using AutoMapper;
using Delivery.Core.Domain.Entities;
using Delivery.Core.Domain.IdentityEntities;
using Delivery.Core.Domain.RepositoryContracts;
using Delivery.Core.DTO;
using Delivery.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Infrastructure.Repositories;

public class DetailsRepository : IDetailsRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public DetailsRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<GetCategoryDto> GetProductsByCategoryIdFromDbAsync(Guid categoryId)
    {
        var result = await _dbContext.Categories
            .Where(x => x.Id == categoryId)
            .Include(x => x.Products)
            .ThenInclude(x => x.ImageUrls)
            .Include(x => x.Products)
            .ThenInclude(x => x.ProductType)
            .FirstOrDefaultAsync();
        
        return _mapper.Map<GetCategoryDto>(result);
    }

    public async Task<IEnumerable<GetCategoryMiniDto>> GetAllCategoriesFromDbAsync()
    {
        var result = await _dbContext.Categories
            .Include(x => x.Products)
            .ToListAsync();
        
        return _mapper.Map<IEnumerable<GetCategoryMiniDto>>(result);
    }
    
    public async Task<IEnumerable<GetProductTypeDto>> GetTypesByCategoryIdFromDbAsync(Guid categoryId)
    {
        var result = await _dbContext.ProductTypes
            .Where(x => x.Category!.Id == categoryId)
            .Include(x => x.Products)
            .ToListAsync();
        
        return _mapper.Map<IEnumerable<GetProductTypeDto>>(result);
    }

    public async Task<IEnumerable<GetProductMiniDto>> GetAllProductsFromDbAsync()
    {
        var result = await _dbContext.Products
            .Include(x => x.ImageUrls)
            .Include(x => x.ProductType)
            .ToListAsync();
        
        return _mapper.Map<IEnumerable<GetProductMiniDto>>(result);
    }

    public async Task<GetProductDto> GetProductByIdFromDbAsync(Guid productId)
    {
        var result = await _dbContext.Products
            .Where(x => x.Id == productId)
            .Include(x => x.ImageUrls)
            .Include(x => x.ProductType)
            .Include(x => x.Category)
            .FirstOrDefaultAsync();
        
        return _mapper.Map<GetProductDto>(result);
    }

    public async Task<bool> ProcessOrderInDbAsync(ApplicationUser  user, List<Product> products)
    {
        List<Product> existingProducts = new List<Product>();

        foreach (var product in products)
        {
            var prod = await _dbContext.Products.FindAsync(product.Id);
            existingProducts.Add(prod);
        }
        
        var newOrder = new Order()
        {
            OrdeDate = DateTime.Now,
            Products = existingProducts,
            User = user
        };

        var addResult = await _dbContext.Orders.AddAsync(newOrder);

        if (addResult.State == EntityState.Added)
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
    
    public async Task<IEnumerable<Order>> GetOrdersHistoryFromDbAsync(ApplicationUser  user)
    {
        var history = await _dbContext.Orders
            .Where(x => x.User.Id == user.Id)
            .Include(x => x.Products)
            .ThenInclude(x => x.ImageUrls)
            .Include(x => x.Products)
            .ThenInclude(x => x.ProductType)
            .ToListAsync();

        return history;
    }
}
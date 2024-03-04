using Delivery.Core.Domain.Entities;
using Delivery.Core.Domain.RepositoryContracts;
using Delivery.Core.DTO;
using Delivery.Infrastructure.DbContext;

namespace Delivery.Infrastructure.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AdminRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ProductType> AddTypeToDbAsync(AddProductTypeDto request)
    {
        var category = await _dbContext.FindAsync<Category>(request.CategoryId);
        
        var newType = new ProductType()
        {
            Name = request.Name,
            Category = category
        };

        var result = await _dbContext.ProductTypes.AddAsync(newType);
        await _dbContext.SaveChangesAsync();
        
        return result.Entity;
    }

    public async Task<Category> AddCategoryToDbAsync(AddCategoryDto request)
    {
        var newCategory = new Category()
        {
            Name = request.Name,
            ImageUrl = request.ImageUrl
        };

        var result = await _dbContext.Categories.AddAsync(newCategory);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Product> AddProductToDbAsync(AddProductDto request)
    {
        var category = await _dbContext.FindAsync<Category>(request.CategoryId);
        var productType = await _dbContext.FindAsync<ProductType>(request.ProductTypeId);
        
        var newProduct = new Product()
        {
            Name = request.Name,
            Price = request.Price,
            Category = category,
            ManufactureCountry = request.ManufactureCountry,
            ImageUrls = request.ImageUrls,
            Currency = request.Currency,
            SellingType = request.SellingType,
            Weight = request.Weight,
            Description = request.Description,
            ProductType = productType
        };

        var result = await _dbContext.Products.AddAsync(newProduct);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }
}
using Delivery.Core.Domain.Entities;
using Delivery.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class DetailsController : Controller
{
    private readonly IDetailsService _detailsService;

    public DetailsController(IDetailsService detailsService)
    {
        _detailsService = detailsService;
    }
    
    [HttpGet("get-all-categories")]
    public async Task<ActionResult> GetAllCategories()
    {
        var result = await _detailsService.GetAllCategoriesAsync();

        return Ok(result);
    }
    
    [HttpGet("get-types-by-category-id")]
    public async Task<ActionResult> GetAllTypes([FromQuery] Guid categoryId)
    {
        var result = await _detailsService.GetTypesByCategoryIdAsync(categoryId);
    
        return Ok(result);
    }
    
    [HttpGet("get-product-by-id")]
    public async Task<ActionResult> GetProductById([FromQuery] Guid productId)
    {
        var result = await _detailsService.GetProductByIdFromDbAsync(productId);

        return Ok(result);
    }
    
    [HttpGet("get-products-by-category-id")]
    public async Task<ActionResult> GetProductsByCategoryId([FromQuery] Guid categoryId)
    {
        var result = await _detailsService.GetProductsByCategoryIdAsync(categoryId);

        return Ok(result);
    }

    [Authorize]
    [HttpPost("process-order")]
    public async Task<ActionResult> ProcessOrder([FromBody] List<Product> products)
    {
        var result = await _detailsService.ProcessOrder(products);
        return result ? Ok() : BadRequest();
    }
    
    [Authorize]
    [HttpGet("get-orders-history")]
    public async Task<ActionResult> GetOrdersHistory()
    {
        var result = await _detailsService.GetOrdersHistory();
        return Ok(result);
    }
}
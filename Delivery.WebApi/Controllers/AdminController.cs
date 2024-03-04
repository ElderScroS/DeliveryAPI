using Delivery.Core.DTO;
using Delivery.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AdminController : Controller
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }
    
    [HttpPost("add-type")]
    public async Task<ActionResult> AddType([FromBody] AddProductTypeDto request)
    {
        var result = await _adminService.AddType(request);

        return Ok(result);
    }
    
    [HttpPost("add-category")]
    public async Task<ActionResult> AddCategory([FromBody] AddCategoryDto request)
    {
        var result = await _adminService.AddCategory(request);

        return Ok(result);
    }
    
    [HttpPost("add-product")]
    public async Task<ActionResult> AddProduct([FromBody] AddProductDto request)
    {
        var result = await _adminService.AddProduct(request);

        return Ok(result);
    }
}
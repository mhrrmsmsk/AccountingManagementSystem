using AccountSystem.Dtos.Product;
using AccountSystem.Entities;
using AccountSystem.Helpers;
using AccountSystem.Interfaces;
using AccountSystem.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace AccountSystem.Controllers;
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepo;
    public ProductController(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    [HttpGet]
    [Route("company/{companyId:int}")]
    public async Task<IActionResult> GetByCompanyId([FromRoute] int companyId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var products =  await _productRepo.GetAllByCompanyIdAsync(companyId);
        var productsDto = products.Select(p => p.ToProductResponseDto());
        if (products.Count == 0)
            return NotFound();
        return Ok(productsDto);
    }

    [HttpGet]
    [Route("company/{companyId:int}/search")]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var products = await _productRepo.GetAllAsync(query);
        var productsDto = products.Select(p => p.ToProductResponseDto());
        if (products.Count == 0)
            return NotFound();
        return Ok(productsDto);
    }
    [HttpGet("company/{companyId}/low-stock")]
    public async Task<IActionResult> GetLowStockProducts([FromRoute] int companyId)
    {
        var products = await _productRepo.GetLowStockByCompanyAsync(companyId);
        if (products == null || !products.Any())
            return NotFound(new { message = "No low stock products found." });

        return Ok(products.Select(p => p.ToProductResponseDto()));
    }
    
    [HttpGet("company/{companyId:int}/details")]
    public async Task<IActionResult> GetDetailedProductsByCompany([FromRoute] int companyId)
    {
        var detailedProducts = await _productRepo.GetDetailedByCompanyIdAsync(companyId);
        if (detailedProducts == null || !detailedProducts.Any())
            return NotFound(new { message = "No products found for this company." });

        return Ok(detailedProducts);
    }
    

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var product = await _productRepo.GetByIdAsync(id);
        if (product == null)
            return NotFound();
        return Ok(product.ToProductResponseDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequestDto productDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var productModel = productDto.ToProductFromCreateDto();
        await _productRepo.AddAsync(productModel);
        return CreatedAtAction("GetById", new { id = productModel.Id }, productModel.ToProductResponseDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id)
    {
        return Ok();
    }
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var deletedProduct = await _productRepo.DeleteAsync(id);
        if(deletedProduct == null)
            return NotFound();
     
        return NoContent();
    }
    
}
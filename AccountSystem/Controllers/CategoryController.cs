using AccountSystem.Dtos.Category;
using AccountSystem.Interfaces;
using AccountSystem.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace AccountSystem.Controllers;
[Route("api/categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepo;

    public CategoryController(ICategoryRepository categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }
    
    [HttpGet("company/{companyId}")]
    public async Task<IActionResult> GetByCompanyId(int companyId)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var categories = await _categoryRepo.GetCategoryByCompanyId(companyId);
        var dto = categories.Select(c => c.ToCategoryDto());
        return Ok(dto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var  category = await _categoryRepo.GetCategoryById(id);
        if (category == null)
            return NotFound();
        return Ok(category.ToCategoryDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequestDto requestDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var categoryModel = requestDto.ToCategoryFromCreateDto();
        var category = await _categoryRepo.CreateCategory(categoryModel);
        
        return Ok(category.ToCategoryDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryRequestDto requestDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var categoryModel = requestDto.ToCategoryFromUpdateDto();
        var category = await _categoryRepo.UpdateCategory(id, categoryModel);
        if(category == null)
            return NotFound();
        return Ok(category.ToCategoryDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var category = await _categoryRepo.DeleteCategory(id);
        if(category == null)
            return NotFound();
        
        return NoContent();
    }

    [HttpGet("company/{companyId}/tree")]
    public async Task<IActionResult> GetCategoryTree(int companyId)
    {
        var tree = await _categoryRepo.GetAllCategoriesAsync(companyId);
        return Ok(tree);
    }
}
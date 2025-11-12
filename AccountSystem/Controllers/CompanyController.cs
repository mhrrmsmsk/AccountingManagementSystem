using AccountSystem.Dtos.Company;
using AccountSystem.Interfaces;
using AccountSystem.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace AccountSystem.Controllers;
[Route("api/companies")]
[ApiController]
public class CompanyController :ControllerBase
{
    private readonly ICompanyRepository _companyRepo;
    public CompanyController(ICompanyRepository companyRepo)
    {
        _companyRepo = companyRepo;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var companies = await _companyRepo.GetAllAsync();
        var companyDto = companies.Select(c=>c.ToCompanyDto());
        return Ok(companyDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var company = await _companyRepo.GetByIdAsync(id);
        if(company==null)
            return NotFound("company not  found");
        return Ok(company.ToCompanyDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompanyRequestDto companyRequestDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var companyModel = companyRequestDto.ToCompanyFromCreateDto();
        await _companyRepo.CreateAsync(companyModel);
        return CreatedAtAction("GetById", new { id = companyModel.Id }, companyModel.ToCompanyDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCompanyRequestDto companyRequestDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var companyModel = await _companyRepo.UpdateAsync(id, companyRequestDto);
        if (companyModel == null)
            return NotFound();
        return Ok(companyModel.ToCompanyDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var companyModel = await _companyRepo.DeleteAsync(id);
        if (companyModel == null)
            return NotFound();
        return NoContent();
    }
}
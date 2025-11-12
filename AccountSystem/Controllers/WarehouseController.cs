using AccountSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountSystem.Controllers;
[Route("api/warehouses")]
[ApiController]
public class WarehouseController: ControllerBase
{
    private readonly IWarehouseRepository _warehouseRepo;

    public WarehouseController(IWarehouseRepository warehouseRepo)
    {
        _warehouseRepo = warehouseRepo;
    }

    [HttpGet("company/{companyId}")]
    public async Task<IActionResult> GetByCompanyId(int companyId)
    {
        return Ok();
    }
    
}
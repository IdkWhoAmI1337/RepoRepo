using Microsoft.AspNetCore.Mvc;
using WebApplication3.DTOs;
using WebApplication3.Services;

namespace WebApplication3.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController(ICustomersService customersService) : ControllerBase
{
    [HttpGet("/api/[controller]/{customerId}/purchases")]
    public async Task<ActionResult<CustomerGetDto>> GetCustomerPurchases(int customerId)
    {
        try
        {
            return Ok(await customersService.GetCustomerPurchases(customerId));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomerWithPurchases(CustomerPostDto request)
    {
        try
        {
            await customersService.AddCustomerWithPurchases(request);
            return CreatedAtAction(nameof(GetCustomerPurchases), 
                new { customerId = request.Customer.Id }, null);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
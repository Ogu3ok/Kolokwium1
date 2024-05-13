using Kolos1.Models;
using Kolos1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FIreController : ControllerBase
{
    private readonly FireService _fireService;

    public FIreController(FireService fireService)
    {
        _fireService = fireService;
    }

    [HttpGet("{id:int}")]
    public IActionResult FireAction(int id)
    {
        FireAction fireAction=  _fireService.GetFireAction(id);
        if (fireAction == null) return NotFound();
        return Ok(fireAction);
    }
    
    
}
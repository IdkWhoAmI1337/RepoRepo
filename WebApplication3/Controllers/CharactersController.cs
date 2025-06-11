using Microsoft.AspNetCore.Mvc;
using WebApplication3.DTOs;
using WebApplication3.Services;

namespace WebApplication3.Controllers;

[ApiController]
[Route("api/[controller]/{characterId:int}")]
public class CharactersController(ICharacterService characterService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CharacterGetDto>> GetCharacterById([FromRoute] int characterId)
    {
        try
        {
            return Ok(await characterService.GetCharacterById(characterId));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("backpacks")]
    public async Task<IActionResult> AddItemsToBackpack([FromRoute] int characterId, [FromBody] List<int> request)
    {
        try
        {
            await characterService.AddItemsToBackpack(characterId, request);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
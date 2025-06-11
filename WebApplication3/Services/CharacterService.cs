using WebApplication3.Data;
using WebApplication3.DTOs;

namespace WebApplication3.Services;

public interface ICharacterService
{
    Task<CharacterGetDto> GetCharacterById(int characterId);
    Task AddItemsToBackpack(int characterId, CharacterPostDto request);
}

public class CharacterService(AppDbContext context) : ICharacterService
{
    public async Task<CharacterGetDto> GetCharacterById(int characterId)
    {
    }

    public async Task AddItemsToBackpack(int characterId, CharacterPostDto request)
    {
    }
}
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.DTOs;
using WebApplication3.Models;

namespace WebApplication3.Services;

public interface ICharacterService
{
    Task<CharacterGetDto> GetCharacterById(int characterId);
    Task<int> AddItemsToBackpack(int characterId, CharacterPostDto request);
}

public class CharacterService(AppDbContext context) : ICharacterService
{
    public async Task<CharacterGetDto> GetCharacterById(int characterId)
    {
        var character = await context.Characters
            .Include(c => c.Backpacks)
            .ThenInclude(b => b.Item)
            .Include(c => c.CharacterTitles)
            .ThenInclude(t => t.Title)
            .FirstOrDefaultAsync(c => c.CharacterId == characterId);

        if (character == null)
        {
            throw new ArgumentException("Character not found");
        }
        
        var backpackItems = character.Backpacks.Select(backpack => new CharacterGetDto.BackpackItem
        {
            ItemName = backpack.Item.Name,
            ItemWeight = backpack.Item.Weight,
            Amount = backpack.Amount
        }).ToList();
        var titles = character.CharacterTitles.Select(t => new CharacterGetDto.Title
        {
            Name = t.Title.Name,
            AquiredAt = t.AcquiredAt
        }).ToList();

        return new CharacterGetDto
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = backpackItems,
            Titles = titles
        };
    }

    public async Task<int> AddItemsToBackpack(int characterId, CharacterPostDto request)
    {
        return 1;
    }
}
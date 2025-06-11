using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models;

public class Character
{
    [Key] public int CharacterId { get; set; }
    [MaxLength(50)] public string FirstName { get; set; } = null!;
    [MaxLength(150)] public string LastName { get; set; } = null!;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public virtual ICollection<Backpack> Backpacks { get; set; } = null!;
    public virtual ICollection<CharacterTitle> CharacterTitles { get; set; } = null!;
}
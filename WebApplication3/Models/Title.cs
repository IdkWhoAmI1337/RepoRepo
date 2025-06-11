using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models;

public class Title
{
    public int TitleId { get; set; }
    [MaxLength(100)] public string Name { get; set; } = null!;
    public virtual ICollection<CharacterTitle> CharacterTitles { get; set; } = null!;
}
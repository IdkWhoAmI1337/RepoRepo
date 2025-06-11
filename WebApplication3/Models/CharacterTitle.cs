using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("Character_Title")]
[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class CharacterTitle
{
    [Column("Character_ID")] public int CharacterId { get; set; }
    [Column("Title_ID")] public int TitleId { get; set; }
    public DateTime AcquiredAt { get; set; }
    [ForeignKey(nameof(CharacterId))] public virtual Character Character { get; set; } = null!;
    [ForeignKey(nameof(TitleId))] public virtual Title Title { get; set; } = null!;
}
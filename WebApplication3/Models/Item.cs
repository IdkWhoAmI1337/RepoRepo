using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models;

public class Item
{
    [Key] public int ItemId { get; set; }
    [MaxLength(100)] public string Name { get; set; } = null!;
    public int Weight { get; set; }
    public virtual ICollection<Backpack> Backpacks { get; set; } = null!;
}
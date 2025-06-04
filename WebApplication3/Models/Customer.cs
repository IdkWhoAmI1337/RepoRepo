using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models;

public class Customer
{
    [Key] public int CustomerId { get; set; }
    
    [MaxLength(50)] public string FirstName { get; set; } = null!;
    
    [MaxLength(100)] public string LastName { get; set; } = null!;
    
    [MaxLength(100)] public string? PhoneNumber { get; set; }
    
    public ICollection<Purchase> Purchases { get; set; } = null!;
}
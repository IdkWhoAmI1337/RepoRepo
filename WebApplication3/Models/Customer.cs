using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required] [MaxLength(50)] public string FirstName { get; set; } = null!;

    [Required] [MaxLength(100)] public string LastName { get; set; } = null!;

    [MaxLength(100)] public string? PhoneNumber { get; set; }

    public ICollection<PurchasedTicket> PurchasedTickets { get; set; } = null!;
}
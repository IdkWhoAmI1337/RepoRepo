using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models;

public class Ticket
{
    [Key] public int TicketId { get; set; }

    [MaxLength(50)] public string SerialNumber { get; set; } = null!;

    public int SeatNumber { get; set; }

    public virtual Concert Concert { get; set; } = null!;
}
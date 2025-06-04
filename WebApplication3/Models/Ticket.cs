using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models;

public class Ticket
{
    [Key] public int TicketId { get; set; }

    [Required] [MaxLength(50)] public string SerialNumber { get; set; } = null!;
    
    [Required] public int SeatNumber { get; set; }

    public virtual ICollection<TicketConcert> TicketConcerts { get; set; } = null!;
}
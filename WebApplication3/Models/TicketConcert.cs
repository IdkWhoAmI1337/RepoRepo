using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models;

public class TicketConcert
{
    [Key] public int TicketConcertId { get; set; }

    [Column("TicketId")] public int TicketId { get; set; }

    [Column("ConcertId")] public int ConcertId { get; set; }

    public decimal Price { get; set; }
    
    [ForeignKey("TicketId")] public virtual Ticket Ticket { get; set; } = null!;

    [ForeignKey("ConcertId")] public virtual Concert Concert { get; set; } = null!;
}
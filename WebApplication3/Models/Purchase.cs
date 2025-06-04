using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models;

public class Purchase
{
    [Key] public int Id { get; set; }

    public DateTime Date { get; set; }

    [Column("CustomerId")] public int CustomerId { get; set; }

    [Column("TicketConcertId")] public int TicketConcertId { get; set; }

    [ForeignKey("CustomerId")] public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("TicketConcertId")] public virtual TicketConcert TicketConcert { get; set; } = null!;
}
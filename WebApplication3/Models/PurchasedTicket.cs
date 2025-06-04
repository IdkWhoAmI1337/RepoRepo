using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models;

public class PurchasedTicket
{
    [Key, Column(Order = 0)] public int TicketConcertId { get; set; }

    [Key, Column(Order = 1)] public int CustomerId { get; set; }
    
    [Required] public DateTime PurchaseDate { get; set; }

    [ForeignKey("CustomerId")] public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("TicketConcertId")] public virtual TicketConcert TicketConcert { get; set; } = null!;
}
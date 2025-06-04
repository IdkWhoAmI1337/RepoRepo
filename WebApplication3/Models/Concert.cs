using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models;

public class Concert
{
    [Key] public int ConcertId { get; set; }
    
    [Required] [MaxLength(100)] public string Name { get; set; } = null!;
    
    public DateTime Date { get; set; }
    
    public int AvailableTickets { get; set; }
    
    public virtual ICollection<TicketConcert> TicketConcerts { get; set; } = null!;
}
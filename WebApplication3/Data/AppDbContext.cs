using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<PurchasedTicket> PurchasedTickets { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Concert>().HasData(
            new Concert
            {
                ConcertId = 1,
                Name = "Summer Rock Festival",
                Date = new DateTime(2025, 7, 15),
                AvailableTickets = 150
            }
        );
        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                CustomerId = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                PhoneNumber = "555-123-456"
            }
        );
        modelBuilder.Entity<Ticket>().HasData(
            new Ticket
            {
                TicketId = 1,
                SerialNumber = "SN123456",
                SeatNumber = 12,
            }
        );
        modelBuilder.Entity<TicketConcert>().HasData(
            new TicketConcert
            {
                TicketConcertId = 1,
                TicketId = 1,
                ConcertId = 1,
                Price = 99.99
            }
        );
    }
    
}
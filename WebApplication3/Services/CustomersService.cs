using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.DTOs;
using WebApplication3.Models;

namespace WebApplication3.Services;

public interface ICustomersService
{
    Task<CustomerGetDto> GetCustomerPurchases(int customerId);
    Task AddCustomerWithPurchases(CustomerPostDto request);
}

public class CustomersService(AppDbContext context) : ICustomersService
{
    public async Task<CustomerGetDto> GetCustomerPurchases(int customerId)
    {
        var customer = await context.Customers
            .Include(c => c.PurchasedTickets)
            .ThenInclude(p => p.TicketConcert)
            .ThenInclude(tc => tc.Concert)
            .Include(c => c.PurchasedTickets)
            .ThenInclude(p => p.TicketConcert)
            .ThenInclude(tc => tc.Ticket)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        if (customer == null) throw new ArgumentException("Customer not found");

        return new CustomerGetDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Purchases = customer.PurchasedTickets.Select(p => new CustomerGetDto.PurchaseDto
            {
                Date = p.PurchaseDate,
                Price = p.TicketConcert.Price,
                Ticket = new CustomerGetDto.TicketDto
                {
                    Serial = p.TicketConcert.Ticket.SerialNumber,
                    SeatNumber = p.TicketConcert.Ticket.SeatNumber
                },
                Concert = new CustomerGetDto.ConcertDto
                {
                    Name = p.TicketConcert.Concert.Name,
                    Date = p.TicketConcert.Concert.Date
                }
            }).ToList()
        };
    }

    public async Task AddCustomerWithPurchases(CustomerPostDto request)
    {
        if (await context.Customers.AnyAsync(c => c.CustomerId == request.Customer.Id))
        {
            throw new InvalidOperationException("Customer already exists");
        }
        
        var customer = new Customer
        {
            CustomerId = request.Customer.Id,
            FirstName = request.Customer.FirstName,
            LastName = request.Customer.LastName,
            PhoneNumber = request.Customer.PhoneNumber
        };

        await context.Customers.AddAsync(customer);
        await context.SaveChangesAsync();
        
        foreach (var purchase in request.Purchases)
        {
            var concert = await context.Concerts
                .FirstOrDefaultAsync(c => c.Name == purchase.ConcertName);

            if (concert == null)
            {
                throw new ArgumentException($"Concert '{purchase.ConcertName}' not found");  
            }
            
            var existingTicketsCount = await context.PurchasedTickets
                .CountAsync(p => p.CustomerId == customer.CustomerId && 
                                p.TicketConcert.ConcertId == concert.ConcertId);

            if (existingTicketsCount + 1 > 5)
            {
                throw new InvalidOperationException("Cannot buy more than 5 tickets for the same concert"); 
            }

            var sn = $"TK{DateTime.Now:yyyyMMddHHmmss}-{purchase.SeatNumber}";
            
            var newTicket = new Ticket
            {
                SerialNumber = sn,
                SeatNumber = purchase.SeatNumber
            };
            
            await context.Tickets.AddAsync(newTicket);
            await context.SaveChangesAsync();

            newTicket = await context.Tickets.FirstOrDefaultAsync(t => t.SerialNumber == sn);

            if (newTicket == null)
            {
                throw new ArgumentException($"Ticket '{sn}' not found");
            }
            
            var newConcert = await context.Concerts.FirstOrDefaultAsync(c => c.Name == purchase.ConcertName);

            if (newConcert == null)
            {
                throw new ArgumentException($"Ticket '{sn}' not found");
            }
            
            var newPurchasedTicket = new PurchasedTicket
            {
                PurchaseDate = DateTime.Now,
                Customer = customer,
                TicketConcert = new TicketConcert
                {
                    TicketId = newTicket.TicketId,
                    ConcertId = newConcert.ConcertId,
                    Price = purchase.Price
                }
            };
            
            await context.PurchasedTickets.AddAsync(newPurchasedTicket);
        }

        await context.SaveChangesAsync();
    }
}
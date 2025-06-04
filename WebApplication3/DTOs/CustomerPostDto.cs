namespace WebApplication3.DTOs;

public class CustomerPostDto
{
    public CustomerDto Customer { get; set; } = null!;
    public List<PurchaseItemDto> Purchases { get; set; } = null!;
    
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
    
    public class PurchaseItemDto
    {
        public int SeatNumber { get; set; }
        public string ConcertName { get; set; } = null!;
        public double Price { get; set; }
    }
}
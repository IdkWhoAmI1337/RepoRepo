using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    
}
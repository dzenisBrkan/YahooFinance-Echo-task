using Microsoft.EntityFrameworkCore;
using Yahoo_Finance.Models;

namespace Yahoo_Finance.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Finance> Finances { get; set; }
}

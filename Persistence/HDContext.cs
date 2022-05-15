using Microsoft.EntityFrameworkCore;
using Persistence.Models;
#pragma warning disable CS8618

namespace Persistence;

public class HDContext : DbContext
{
    public HDContext(DbContextOptions<HDContext> options) : base(options)
    {
        
    }
    
    public DbSet<Project> Projects { get; set; }
}
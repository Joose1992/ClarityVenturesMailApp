using ClarityVenturesMailData.Model;
using Microsoft.EntityFrameworkCore;

namespace ClarityVenturesMailData.Context;

public class EmailContext : DbContext
{
    public EmailContext()
    {
        
    }

    public EmailContext(DbContextOptions<EmailContext> options) : base(options)
    {
        
    }
    
    public DbSet<Email> Emails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Email>(
            entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);

                entity.Property(e => e.DateTime)
                    .IsRequired();
                
            }
        );
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace appblazor.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

        if (!dbCreator.CanConnect())
            dbCreator.Create();

        if (!dbCreator.HasTables())
            dbCreator.CreateTables();
    }   

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Contact>().HasData(
            new Contact() { Id = 1, Name = "Sergio", Email = "teste"}
        );

        base.OnModelCreating(builder);
    }

    public DbSet<Contact> Contacts { get; set; }
}

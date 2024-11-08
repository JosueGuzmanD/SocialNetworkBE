using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Infrastructure;

public class SocialNetworkDbContext : IdentityDbContext<ApplicationUser>
{
    public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options) : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<FootballField> FootballFields { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Reaction> Reactions { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamMembership> TeamMemberships { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Player>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SocialNetworkDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Player>()
            .HasOne(p => p.ApplicationUser)
            .WithOne(au => au.Player)
            .HasForeignKey<ApplicationUser>(au => au.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
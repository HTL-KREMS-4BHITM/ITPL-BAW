using BAWLib.Entities;
using Microsoft.EntityFrameworkCore;

namespace BAWLib.Configs;

public class MotorContext : DbContext
{
   

    public MotorContext(DbContextOptions<MotorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Motorbike> Motorbikes { get; set; }    
    public virtual DbSet<Groups> Groups { get; set; }
    public virtual DbSet<Waypoint> Waypoints { get; set; }
    public virtual DbSet<Favorite> Favorites_JT { get; set; }
    public virtual DbSet<LeasingContract> LeasingContractsJts { get; set; }

    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Favorite>()
            .HasKey(f => new { MotorbikeID = f.Motorbike_ID, UserID = f.User_ID});
        modelBuilder.Entity<LeasingContract>()
            .HasKey(lc => new{lc.MotorbikeID, lc.UserID, lc.FROM_DATE});
        modelBuilder.Entity<User>()
            .HasOne(u => u.Group)
            .WithMany(g =>g.Users)
            .HasForeignKey(u => u.GroupID);
        modelBuilder.Entity<Waypoint>()
            .HasOne(w => w.Group)
            .WithMany(g => g.Waypoints)
            .HasForeignKey(w => w.RouteID);
        modelBuilder.Entity<LeasingContract>()
            .HasOne(lc => lc.User)
            .WithMany(u => u.LeasingContracts)
            .HasForeignKey(lc => lc.UserID);
        modelBuilder.Entity<LeasingContract>()
            .HasOne(lc => lc.Motorbike)
            .WithMany(m => m.LeasingContracts)
            .HasForeignKey(lc => lc.MotorbikeID);
        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.User_ID);
        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.Motorbike)
            .WithMany(m => m.Favorites)
            .HasForeignKey(f => f.Motorbike_ID); 
    }
        
}
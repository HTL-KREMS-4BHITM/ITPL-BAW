using System.ComponentModel.Design;
using BAWLib;
using Microsoft.EntityFrameworkCore;

public class MotorContext : DbContext
{
   

    public MotorContext(DbContextOptions<MotorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Motorbike> Motorbikes { get; set; }
    public virtual DbSet<Group> Groups { get; set; }
    public virtual DbSet<Waypoint> Waypoints { get; set; }
    public virtual DbSet<Favorite> Favorites_JT { get; set; }
    public virtual DbSet<LeasingContract> LeasingContractsJts { get; set; }

    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Favorite>()
            .HasKey(f => new {f.MotorbikeID, f.UserID});
        modelBuilder.Entity<LeasingContract>()
            .HasKey(lc => new{lc.MotorbikeID, lc.UserID, lc.FROM_DATE});
        modelBuilder.Entity<User>()
            .HasOne(u => u.Group)
            .WithMany(g =>g.Users)
            .HasForeignKey(u => u.GroupID);
        modelBuilder.Entity<Group>()
            .HasMany(g => g.Waypoints)
            .WithOne()
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
            .HasForeignKey(f => f.UserID);
        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.Motorbike)
            .WithMany(m => m.Favorites)
            .HasForeignKey(f => f.MotorbikeID); 
    }
        
}
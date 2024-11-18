using BAWLib;
using Microsoft.EntityFrameworkCore;

public class MotorContext : DbContext
{
   

    public MotorContext(DbContextOptions<MotorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Leasing_Contract_Jt> LeasingContractsJts { get; set; }

    public virtual DbSet<Motorbike> Motorbikes { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Waypoint> Waypoints { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=motordb;user id=root;password=123mysql", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PRIMARY");

            entity.ToTable("GROUPS");

            entity.HasIndex(e => e.GroupId, "GROUP_ID_UNIQUE").IsUnique();

            entity.Property(e => e.GroupId)
                .ValueGeneratedNever()
                .HasColumnName("GROUP_ID");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.From_Date).HasColumnName("FROM_DATE");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("NAME");
            entity.Property(e => e.Route_Id).HasColumnName("ROUTE_ID");
            entity.Property(e => e.To_Date).HasColumnName("TO_DATE");
        });

        modelBuilder.Entity<Leasing_Contract_Jt>(entity =>
        {
            entity.HasKey(e => new { e.UserID, e.MotorbikeID })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("LEASING_CONTRACTS_JT");

            entity.HasIndex(e => e.MotorbikeID, "fk_USERS_has_BIKESJT_BIKES1_idx");

            entity.HasIndex(e => e.UserID, "fk_USERS_has_BIKESJT_USERS_idx");

            entity.Property(e => e.UserID).HasColumnName("USER_ID");
            entity.Property(e => e.MotorbikeID).HasColumnName("MOTORBIKE_ID");
            entity.Property(e => e.COST)
                .HasPrecision(8, 2)
                .HasColumnName("COST");
            entity.Property(e => e.FROM_DATE).HasColumnName("FROM_DATE");
            entity.Property(e => e.TO_DATE).HasColumnName("TO_DATE");

            entity.HasOne(d => d.Motorbike).WithMany(p => p.Leasing_Contract_Jts)
                .HasForeignKey(d => d.MotorbikeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_USERS_has_BIKESJT_BIKES1");

            entity.HasOne(d => d.User).WithMany(p => p.Leasing_Contract_Jts)
                .HasPrincipalKey(p => p.User_Id)
                .HasForeignKey(d => d.UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_USERS_has_BIKESJT_USERS");
        });

        modelBuilder.Entity<Motorbike>(entity =>
        {
            entity.HasKey(e => e.Motorbike_ID).HasName("PRIMARY");

            entity.ToTable("MOTORBIKES");

            entity.HasIndex(e => e.Motorbike_ID, "BIKE_ID_UNIQUE").IsUnique();

            entity.Property(e => e.Motorbike_ID).HasColumnName("MOTORBIKE_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.CurrentLeasingRate)
                .HasPrecision(6, 2)
                .HasColumnName("CURRENTLEASINGRATE");
            entity.Property(e => e.Federal_State)
                .HasMaxLength(45)
                .HasColumnName("FEDERAL_STATE");
            entity.Property(e => e.Kilometer)
                .HasPrecision(10)
                .HasColumnName("KILOMETER");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .HasColumnName("MANUFACTORER");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("MODEL");
            entity.Property(e => e.Ps).HasColumnName("PS");
            entity.Property(e => e.SeatHeight).HasColumnName("SEATHEIGHT");
            entity.Property(e => e.Weight).HasColumnName("WEIGHT");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.RouteID).HasName("PRIMARY");

            entity.ToTable("ROUTES");

            entity.Property(e => e.RouteID).HasColumnName("ROUTEID");
            entity.Property(e => e.Created_At)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.GroupId).HasColumnName("GROUPID");
            entity.Property(e => e.RouteData)
                .HasColumnType("json")
                .HasColumnName("ROUTEDATA");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => new { e.User_Id, e.Group_Id })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("USERS");

            entity.HasIndex(e => e.Password, "PASSWORD_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Username, "USERNAME_UNIQUE").IsUnique();

            entity.HasIndex(e => e.User_Id, "USER_ID_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Group_Id, "fk_USERS_GROUPS1_idx");

            entity.Property(e => e.User_Id).HasColumnName("USER_ID");
            entity.Property(e => e.Group_Id).HasColumnName("GROUP_ID");
            entity.Property(e => e.Age).HasColumnName("AGE");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("USERNAME");

            /* entity.HasOne(d => Group).WithMany(p => p.Users)
                 .HasForeignKey(d => d.GroupId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("fk_USERS_GROUPS1");
 */
            /*entity.HasMany(d => d.Motorbikes).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "FavoritesJt",
                    r => r.HasOne<Motorbike>().WithMany()
                        .HasForeignKey("MotorbikeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_USERS_has_BIKESJT_BIKES2"),
                    l => l.HasOne<User>().WithMany()
                        .HasPrincipalKey("UserId")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_USERS_has_BIKESJT_USERS1"),
                    j =>
                    {
                        j.HasKey("UserId", "MotorbikeId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("FAVORITES_JT");
                        j.HasIndex(new[] { "MotorbikeId" }, "fk_USERS_has_BIKESJT_BIKES2_idx");
                        j.HasIndex(new[] { "UserId" }, "fk_USERS_has_BIKESJT_USERS1_idx");
                        j.IndexerProperty<int>("UserId").HasColumnName("USER_ID");
                        j.IndexerProperty<int>("MotorbikeId").HasColumnName("MOTORBIKE_ID");
                    });
        });*/

            modelBuilder.Entity<Waypoint>(entity =>
            {
                entity.HasKey(e => e.Address_ID).HasName("PRIMARY");

                entity.ToTable("WAYPOINTS");

                entity.HasIndex(e => e.Route_Id, "ROUTEID");

                entity.Property(e => e.Address_ID).HasColumnName("ADDRESSID");
                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("ADDRESS");
                entity.Property(e => e.Route_Id).HasColumnName("ROUTEID");
                entity.Property(e => e.Sequence).HasColumnName("SEQUENCE");

                entity.HasOne(d => d.Route).WithMany(p => p.Waypoints)
                    .HasForeignKey(d => d.Route_Id)
                    .HasConstraintName("waypoints_ibfk_1");
            });
        });
        
}}
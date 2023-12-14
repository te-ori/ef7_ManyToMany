using Microsoft.EntityFrameworkCore;

namespace M2m;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Role> Roles { get; set; }
}

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<User> Users { get; set; }
}

public class UserRole
{
    public User User { get; set; }
    public Role Role { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
}

public class EfContext : DbContext {
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=M2m;User Id=sa;Password=P@2wo5+-;TrustServerCertificate=True;");
    }

   override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .ToTable("User");

        modelBuilder.Entity<Role>()
        .ToTable("Roles");

        modelBuilder.Entity<UserRole>()
        .ToTable("UsersRoles");


        modelBuilder.Entity<User>()
        .HasMany(u => u.Roles)
        .WithMany(r => r.Users)
        .UsingEntity<UserRole>();   
    }
}
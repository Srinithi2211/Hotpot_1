using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Menu> Menus { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<DashboardUser> DashboardUsers { get; set; }
    public DbSet<DashboardRestaurant> DashboardRestaurants { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
}

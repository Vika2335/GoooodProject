using GoooodProject;
using Microsoft.EntityFrameworkCore;
public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Employee> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=unicorn.db");

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

}

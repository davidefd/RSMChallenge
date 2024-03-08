
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfiguration configuration = new ConfigurationBuilder()
                                           .AddJsonFile("appsettings.json", optional: false)
                                           .Build();
        // Configura la cadena de conexión a tu base de datos
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Connection"));
    }

    public DbSet<PersonModel> PersonModels { get; set; }
    public DbSet<TablePersonModel> TablePersonModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonModel>()
                    .HasNoKey()
                    .ToView("vEmployee", "HumanResources");

        modelBuilder.Entity<TablePersonModel>()
                    .ToTable("Person", "Person")
                    .HasKey(p => p.BusinessEntityID);

        modelBuilder.Entity<TablePersonModel>()
                    .Property(p => p.PersonType).HasColumnType("nchar");

    }

}
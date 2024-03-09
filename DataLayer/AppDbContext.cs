
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
    public DbSet<ProductModel> ProductModels { get; set; }
    public DbSet<SubCategoryModel> SubCategoryModels { get; set; }
    public DbSet<CategoryModel> CategoryModels { get; set; }

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

        modelBuilder.Entity<ProductModel>()
                    .ToTable("Product","Production")
                    .HasKey(p => p.ProductID);

        modelBuilder.Entity<SubCategoryModel>()
                    .ToTable("ProductSubcategory", "Production")
                    .HasKey(p => p.ProductSubcategoryID);

        modelBuilder.Entity<CategoryModel>()
                    .ToTable("ProductCategory", "Production")
                    .HasKey(p => p.ProductCategoryID);
/*       
        modelBuilder.Entity<ProductModel>().HasOne(p => p.SubCategoryModel)
                                           .WithMany(s => s.ProductModels)
                                           .HasForeignKey(p => p.ProductSubcategoryID);
        
        modelBuilder.Entity<SubCategoryModel>().HasOne(s => s.CategoryModel)
                                               .WithMany(c => c.SubCategoryModels)
                                               .HasForeignKey(s => s.ProductCategoryID);
*/
    }

}
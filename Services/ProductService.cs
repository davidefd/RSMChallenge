public class ProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }


    public List<ProductModel>? GetAll()
    {
        try
        {
            List<ProductModel> productModels = _context.ProductModels.ToList();
            return productModels;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JustError: {ex.Message}");
        }
        return null;
    }
}
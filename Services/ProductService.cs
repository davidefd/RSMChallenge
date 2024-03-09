using System.Reflection;

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

    public List<ProductModel>? GetProductByName(string name)
    {
        try
        {
            List<ProductModel> productModels = _context.ProductModels
                                               .Where(e => e.Name == name)
                                               .ToList();
            return productModels;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JustError: {ex.Message}");
        }
        return null;
    }

    /*
    SELECT A.*
FROM [Production].[Product] A
INNER JOIN [Production].[ProductSubcategory] B ON a.ProductSubcategoryID = b.ProductSubcategoryID
INNER JOIN [Production].[ProductCategory] C ON b.ProductCategoryID = c.ProductCategoryID
WHERE c.Name = 'Clothing';
    */
}
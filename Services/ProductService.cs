
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
                                               .Where(e => e.Name != null &&
                                                           e.Name.Contains(name))
                                               .ToList();
            return productModels;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JustError: {ex.Message}");
        }
        return null;
    }

    public List<ProductModel>? GetProductByCategoryType(string categoryType)
    {
        try
        {
            var productModels = _context.ProductModels
                                .Where(p => p.SubCategoryModel != null &&
                                            p.SubCategoryModel.CategoryModel != null &&
                                            p.SubCategoryModel.CategoryModel.Name != null &&
                                            p.SubCategoryModel.CategoryModel.Name.Contains(categoryType))
                                .ToList();

            var result = productModels.ToList();
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JustError: {ex.Message}");
        }
        return null;
    }

    /*
           public List<ProductModel>? GetProductByCategoryType(string categoryType)
           {
               try
               {
                   var productModels = from product in _context.ProductModels
                                       join subCategory in _context.SubCategoryModels on product.ProductSubcategoryID equals subCategory.ProductSubcategoryID
                                       join category in _context.CategoryModels on subCategory.ProductCategoryID equals category.ProductCategoryID
                                       where category.Name == categoryType
                                       select product;

                   var result = productModels.ToList();
                   return result;
               }
               catch (Exception ex)
               {
                   Console.WriteLine($"JustError: {ex.Message}");
               }
               return null;
           }

       */
}
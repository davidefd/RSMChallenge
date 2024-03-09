
public class ProductModel
{
    public int ProductID { get; set; }
    public string? Name { get; set; }
    public string? ProductNumber { get; set; }
    public string? Color { get; set; }
    public decimal? StandardCost { get; set; }
    public decimal? ListPrice { get; set; }

    public int? ProductSubcategoryID { get; set; }
    public SubCategoryModel? SubCategoryModel { get; set; }
    public int? ProductModelID { get; set; }


}
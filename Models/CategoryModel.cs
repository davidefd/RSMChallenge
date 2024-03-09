public class CategoryModel 
{
    public int ProductCategoryID { get; set; }
    public string? Name { get; set; }

    public List<SubCategoryModel>? SubCategoryModels { get; set; }  

}
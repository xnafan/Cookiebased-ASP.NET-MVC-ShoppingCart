namespace CookieCartMVC.DataAccessLayer;
public interface IProductDao
{
    IEnumerable<Product> GetAllProducts();
    int AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
    Product? GetProductById(int id);
}
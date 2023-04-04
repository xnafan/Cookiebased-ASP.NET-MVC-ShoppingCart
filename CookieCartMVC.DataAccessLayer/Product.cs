namespace CookieCartMVC.DataAccessLayer;
public class Product
{
    public int Id { get; internal set; }
    public int Price { get; internal set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}
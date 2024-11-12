using CookieCartMVC.DataAccessLayer;
namespace CookieCartMVC.Models;

/// <summary>
/// The ProductQuantity class is a simple class that represents a product in the cart,
/// with both the product's ID and the quantity of that product in the cart, 
/// with the bare minimum for calculating the total price of the cart and displaying the products' name.
/// </summary>
public class ProductQuantity
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public string Name { get; set; } = string.Empty;

    public ProductQuantity(Product product, int quantity)
    {
        Id = product.Id;
        Price = product.Price;
        Name = product.Name;
        Quantity = quantity;
    }

    public ProductQuantity(){}

    public int GetTotalPrice()
    {
        return Price * Quantity;
    }
}
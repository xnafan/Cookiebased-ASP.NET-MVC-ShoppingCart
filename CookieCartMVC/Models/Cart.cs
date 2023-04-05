namespace CookieCartMVC.Models;

/// <summary>
/// The Cart class encapsulates basic information about products and their quantities.
/// It stores a reduced version of the Product class, which is the ProductQuantity class,
/// in order to be able to calculate price per product and total price 
/// without having to look it up in the database each time it is shown.
/// </summary>
public class Cart
{
    //This property is public in order for it to be serializable (to JSON in this example)
    public Dictionary<int, ProductQuantity> ProductQuantities { get; set; }
    public Cart(Dictionary<int, ProductQuantity>? productQuantities = null)
    {
        ProductQuantities = productQuantities ?? new Dictionary<int, ProductQuantity>(); ;
    }

    public void ChangeQuantity(ProductQuantity productQuantity)
    {
        if (ProductQuantities.ContainsKey(productQuantity.Id))
        {
            ProductQuantities[productQuantity.Id].Quantity += productQuantity.Quantity;
            if (ProductQuantities[productQuantity.Id].Quantity <= 0)
            {
                ProductQuantities.Remove(productQuantity.Id);
            }
        }
        else
        {
            ProductQuantities[productQuantity.Id] = productQuantity;
        }
    }

    public void RemoveProduct(int productId) => ProductQuantities.Remove(productId);
    public void Update(int productId, int quantity) => ProductQuantities[productId].Quantity = quantity;

    #region Helper methods
    //GetTotal and GetNumberOfProducts are methods instead of readonly properties,
    //so they don't give any problems during deserialization
    public int GetTotal()
    {
        int total = 0;
        foreach (ProductQuantity productQuantity in ProductQuantities.Values)
        {
            total += productQuantity.GetTotalPrice();
        }
        return total;
    }
    public int GetNumberOfProducts() => ProductQuantities.Sum(pq => pq.Value.Quantity);
    internal void EmptyAll() => ProductQuantities.Clear();
    #endregion
}
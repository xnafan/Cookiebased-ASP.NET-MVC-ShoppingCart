namespace CookieCartMVC.Models;
public class Cart
{
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

    public void RemoveProduct(int productId)
    {
        ProductQuantities.Remove(productId);
    }

    public void Update(int productId, int quantity)
    {
        ProductQuantities[productId].Quantity = quantity;
    }

    public int GetTotal()
    {
        int total = 0;
        foreach (ProductQuantity productQuantity in ProductQuantities.Values)
        {
            total += productQuantity.GetTotalPrice();
        }
        return total;
    }

    public int GetNumberOfProducts ()
    {
         return ProductQuantities.Sum(pq => pq.Value.Quantity);
    }

    internal void EmptyAll()
    {
        ProductQuantities.Clear();
    }
}
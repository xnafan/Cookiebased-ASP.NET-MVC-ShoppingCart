using CookieCartMVC.DataAccessLayer;

namespace CookieCartMVC.Models
{
    public class ProductQuantity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }

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
}
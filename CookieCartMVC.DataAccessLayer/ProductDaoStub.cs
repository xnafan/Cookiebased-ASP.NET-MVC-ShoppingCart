using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCartMVC.DataAccessLayer
{
    public class ProductDaoStub : IProductDao
    {
        private IEnumerable<Product> _products = new List<Product>()
        {
            new Product() { Id = 1, Name = "Coffee", Price = 10 },
            new Product() { Id = 2, Name = "Apple", Price = 2 },
            new Product() { Id = 3, Name = "Cotton Candy", Price = 5 },
            new Product() { Id = 4, Name = "Corn on the cob", Price = 1},
            new Product() { Id = 5, Name = "Reese's Pieces", Price = 2 },
            new Product() { Id = 6, Name = "Red cabbage", Price = 4 },
            new Product() { Id = 7, Name = "Coleslaw", Price = 7 },
        };
        public int AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            foreach (var product in _products)
            {
                yield return product;
            }
        }

        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

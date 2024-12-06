# Cookie based ASP.NET MVC shopping cart
This project showcases a simple ASP.NET MVC project which consists of two controller classes with functionality for:
- displaying a list of products with their price and a link for adding to basket
- storing the contents of the shopping cart in the visitor's browser
- displaying the content of the cart including the price for single orderlines and the total sum
- adding/removing items and emptying both a single product type or the entire basket

## The shop page (ShopController)
<img width="570" alt="image" src="https://github.com/user-attachments/assets/23202887-04f1-42bd-b48d-2e36a8764470">  

The ShopController is just a list of products with links to the CartController for adding or adjusting the contents of the cart.

## The cart page (CartController)
<img width="585" alt="image" src="https://github.com/user-attachments/assets/bfea4e7f-529b-4756-9ca2-f15f557c6b52">  

The cart is based on two elements, the CartController class and the Cart model class:

### The CartController
The [CartController](CookieCartMVC/Controllers/CartController.cs) is an ASP.NET MVC controller.
It has a reference to a DAL class where it retrieves the products to display, and uses the Cart class to retrieve and save the contents of the cart.  

![image](https://github.com/user-attachments/assets/39ff4a4b-d0ef-4efe-bb8b-78e977ac134b)  

In a real webshop the CartController would also have a reference to a DAL object to place the order.


### The Cart
The [Cart](CookieCartMVC/Models/Cart.cs) is basically a wrapper around a C# Dictionary collection which stores [ProductQuantity](https://github.com/xnafan/Cookiebased-ASP.NET-MVC-ShoppingCart/blob/master/CookieCartMVC/Models/ProductQuantity.cs) helperobjects (value) under the ID of products (key), for easy retrival and look ups. It also serializes and deserializes the cart to and from JSON for storage in a cookie.  

![image](https://github.com/user-attachments/assets/b5b026b9-ec7e-46bf-b644-0b5a1a628d15)

The ProductQuantity objects are simple objects with only the necessary data to display a product's name, the price, the total price and store the ID of the product.
The ProductQuantity has a constructor which receives a Product object and stores the data from the product:  

```C#
 public ProductQuantity(Product product, int quantity)
 {
     Id = product.Id;
     Price = product.Price;
     Name = product.Name;
     Quantity = quantity;
 }
```
...you may have to change this to your product objects (or DTOs), in order to make it work with the product objects in your data access layer.

# What you have to do
The CartController can be imported into your project and used as is.  

## Files
You will need to add the following files to your project
- [Controllers/CartController.cs](CookieCartMVC/Controllers/CartController.cs)  
- [Views/Cart/Index.cshtml](CookieCartMVC/Views/Cart/Index.cshtml)
- [Models/Cart.cs](CookieCartMVC/Models/Cart.cs)
- [Models/ProductQuantity.cs](CookieCartMVC/Models/ProductQuantity.cs)

## Integration with your solution
In your products page you should add links to the CartController in the format:  */Cart/Add/6?quantity=1* where the 6 is the ID of your product and the quantity is how many to add.
If the item wasn't in the cart, this will add an item to the cart in the requested quantity.  
If the item is in the cart already, this will increase(or decrease) the quantity in the cart.  

### Retrieving product info
The cart only stores a minimum of info about the products in order to display them.  
- Id (primary key)
- Name
- Price
- Quantity
This is done in order to avoid having to request this information from the data source (database/API/etc.) every time the cart is displayed.
You have to provide the CartController with a way to get this productinfo, when items are added to the cart, so ProductQuantity objects can be created and stored in the cart.  
In the code sample an IProductDao is used, but the only necessary code, for the cart to work, is a method which can retrieve a product object given an Id, so the properties from that product can be copied to a ProductQuantity object.

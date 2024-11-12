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
The [CartController](https://github.com/xnafan/Cookiebased-ASP.NET-MVC-ShoppingCart/blob/master/CookieCartMVC/Controllers/CartController.cs) is an ASP.NET MVC controller.
It has a reference to a DAL class where it retrieves the products to display, and uses the Cart class to retrieve and save the contents of the cart.  

![image](https://github.com/user-attachments/assets/39ff4a4b-d0ef-4efe-bb8b-78e977ac134b)  

In a real webshop the CartController would also have a reference to a DAL object to place the order.


### The Cart
The [Cart](https://github.com/xnafan/Cookiebased-ASP.NET-MVC-ShoppingCart/blob/master/CookieCartMVC/Models/Cart.cs) is basically a wrapper around a C# Dictionary collection which stores [ProductQuantity](https://github.com/xnafan/Cookiebased-ASP.NET-MVC-ShoppingCart/blob/master/CookieCartMVC/Models/ProductQuantity.cs) helperobjects (value) under the ID of products (key), for easy retrival and look ups. It also serializes and deserializes the car to and from JSON for storage in a cookie.  

![image](https://github.com/user-attachments/assets/b5b026b9-ec7e-46bf-b644-0b5a1a628d15)



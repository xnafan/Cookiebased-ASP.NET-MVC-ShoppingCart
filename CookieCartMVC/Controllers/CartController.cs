using CookieCartMVC.DataAccessLayer;
using CookieCartMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CookieCartMVC.Controllers;
public class CartController : Controller
{

    IProductDao _productDao;

    public CartController(IProductDao productDao) => _productDao = productDao;

    public ActionResult Index()
    {
        return View(GetCartFromCookie());
    }


    // GET: CartController/Edit/5?quantity=3
    public ActionResult Edit(int id, int quantity)
    {
        var cart = LoadChangeAndSaveCart(cart => cart.ChangeQuantity(new ProductQuantity(_productDao.GetProductById(id), quantity)));
        return View("Index", cart);
    }

    // GET: CartController/Add/5?quantity=3
    public ActionResult Add(int id, int quantity)
    {
        var cart = LoadChangeAndSaveCart(cart => cart.ChangeQuantity(new ProductQuantity(_productDao.GetProductById(id), quantity)));
        return RedirectToAction("Index", cart);
    }

    // GET: CartController/Delete/5
    public ActionResult Delete(int id)
    {
        var cart = LoadChangeAndSaveCart(cart => cart.RemoveProduct(id));
        return RedirectToAction("Index", cart);
    }

    public ActionResult EmptyCart()
    {
        var cart = LoadChangeAndSaveCart(cart => cart.EmptyAll());
        return RedirectToAction("Index", cart);
    }
    private void SaveCartToCookie(Cart cart)
    {
        var cookieOptions = new CookieOptions();
        cookieOptions.Expires = DateTime.Now.AddDays(7);
        cookieOptions.Path = "/";
        Response.Cookies.Append("Cart", JsonSerializer.Serialize(cart), cookieOptions);
    }

    private Cart GetCartFromCookie()
    {
        Request.Cookies.TryGetValue("Cart", out string? cookie);
        if (cookie == null) { return new Cart(); }
        return JsonSerializer.Deserialize<Cart>(cookie) ?? new Cart();
    }
    private Cart LoadChangeAndSaveCart(Action<Cart> action)
    {
        Cart cart = GetCartFromCookie();
        action(cart);
        ViewBag.Cart = cart;
        SaveCartToCookie(cart);
        return cart;
    }
}

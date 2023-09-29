using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Test1.Models;

namespace Test1.Controllers
{
    public class ShoppingCartController : Controller
    {
        private const string CartSessionKey = "Cart";

        // Action to display the cart
        public ActionResult Cart()
        {
            var cart = GetCartFromSession();
            return View(cart);
        }

        // Action to add a product to the cart
        public ActionResult AddToCart(int productId, int quantity)
        {
            var product = GetProductById(productId);

            if (product != null && quantity > 0)
            {
                var cart = GetCartFromSession();
                var cartItem = cart.FirstOrDefault(item => item.ProductId == productId);

                if (cartItem != null)
                {
                    // Update quantity if the product is already in the cart
                    cartItem.Quantity += quantity;
                }
                else
                {
                    // Add a new item to the cart
                    cart.Add(new CartItem
                    {
                        ProductId = productId,
                        ProductName = product.Name,
                        Price = product.Price,
                        Quantity = quantity
                    });
                }

                SaveCartToSession(cart);
            }

            return RedirectToAction("Cart");
        }

        // Action to update the quantity of a cart item
        public ActionResult UpdateCartItem(int productId, int quantity)
        {
            var cart = GetCartFromSession();
            var cartItem = cart.FirstOrDefault(item => item.ProductId == productId);

            if (cartItem != null && quantity > 0)
            {
                cartItem.Quantity = quantity;
                SaveCartToSession(cart);
            }

            return RedirectToAction("Cart");
        }

        // Action to remove a cart item
        public ActionResult RemoveCartItem(int productId)
        {
            var cart = GetCartFromSession();
            var cartItem = cart.FirstOrDefault(item => item.ProductId == productId);

            if (cartItem != null)
            {
                cart.Remove(cartItem);
                SaveCartToSession(cart);
            }

            return RedirectToAction("Cart");
        }

        private Product GetProductById(int productId)
        {
            // Implement your actual product retrieval logic here (e.g., fetch from the database)
            // Replace the following code with your database query or repository method

            // Assuming you have a database context named dbContext
            using (var dbContext = new ApplicationDbContext())
            {
                var product = dbContext.Products.FirstOrDefault(p => p.ProductId == productId);
                return product;
            }
        }


        // Helper method to get the cart from the session
        private List<CartItem> GetCartFromSession()
        {
            var cart = Session[CartSessionKey] as List<CartItem>;
            return cart ?? new List<CartItem>();
        }

        // Helper method to save the cart to the session
        private void SaveCartToSession(List<CartItem> cart)
        {
            Session[CartSessionKey] = cart;
        }
    }
}

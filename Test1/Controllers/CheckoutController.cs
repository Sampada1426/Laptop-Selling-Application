using System;
using System.Web.Mvc;
using Test1.Models;

namespace Test1.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CheckoutController()
        {
            dbContext = new ApplicationDbContext(); // Initialize your DbContext here
        }

        // Step 1: Shipping and Payment
        [HttpGet]
        public ActionResult Checkout()
        {
            // Provide a view for users to enter shipping and payment information
            var checkoutModel = new CheckoutViewModel();
            return View(checkoutModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(CheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Step 2: Store shipping and payment information
                var shippingInfo = new ShippingInfo
                {
                    FullName = model.FullName,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    PostalCode = model.PostalCode,
                    Phone = model.Phone,
                    Email = model.Email,
                    ShippingMethod = model.ShippingMethod
                };

                var paymentInfo = new PaymentInfo
                {
                    CardNumber = model.CardNumber,
                    ExpirationMonth = model.ExpirationMonth,
                    ExpirationYear = model.ExpirationYear,
                    CVV = model.CVV
                };

                // Calculate shipping cost based on the selected shipping method
                decimal shippingCost = CalculateShippingCost(model.ShippingMethod);

                // Store shipping, payment information, and shipping cost in the session
                Session["ShippingInfo"] = shippingInfo;
                Session["PaymentInfo"] = paymentInfo;
                Session["ShippingCost"] = shippingCost;

                // Proceed to order confirmation step
                return RedirectToAction("OrderConfirmation");
            }

            // If ModelState is not valid, redisplay the checkout form
            return View(model);
        }

        // Helper method to calculate shipping cost (you can replace this with your logic)
        private decimal CalculateShippingCost(string shippingMethod)
        {
            // Replace this with your logic to calculate shipping cost
            // Example: calculate based on shippingMethod parameter
            if (shippingMethod == "Standard")
            {
                return 5.99M;
            }
            else if (shippingMethod == "Expedited")
            {
                return 12.99M;
            }
            else
            {
                return 0M; // No shipping cost for other methods
            }
        }

        // Step 3: Order Confirmation
        //public ActionResult OrderConfirmation()
        //{
        //    // Retrieve the stored shipping and payment information
        //    var shippingInfo = Session["ShippingInfo"] as ShippingInfo;
        //    var paymentInfo = Session["PaymentInfo"] as PaymentInfo;
        //    var shippingCost = (decimal)Session["ShippingCost"];

        //    // Create an order with shipping, payment information, and total cost
        //    var order = new Order
        //    {
        //        ShippingInfo = shippingInfo,
        //        PaymentInfo = paymentInfo,
        //        ShippingCost = shippingCost,
        //        // Add additional order details as needed
        //    };

        //    // Save the order to the database or perform other order processing

        //    // Clear the session data
        //    Session.Remove("ShippingInfo");
        //    Session.Remove("PaymentInfo");
        //    Session.Remove("ShippingCost");

        //    return View(order);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

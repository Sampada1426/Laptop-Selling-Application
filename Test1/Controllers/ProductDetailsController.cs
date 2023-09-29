using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;

namespace Test1.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ProductDetailsController()
        {
            dbContext = new ApplicationDbContext(); // Initialize your DbContext here
        }

        public ActionResult ProductDetails(int id)
        {
            // Retrieve the product details by ID from the database
            var product = dbContext.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound(); // Handle product not found
            }

            return View(product);
        }

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
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;

namespace Test1.Controllers
{
    public class ProductCatalogController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ProductCatalogController()
        {
            dbContext = new ApplicationDbContext(); // Initialize your DbContext here
        }

        public ActionResult ProductCatalog()
        {
            // Retrieve a list of products from the database
            var products = dbContext.Products.ToList();
            return View(products);
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
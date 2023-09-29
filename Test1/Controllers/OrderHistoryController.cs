//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Test1.Models;

//namespace Test1.Controllers
//{
//    public class OrderHistoryController : Controller
//    {
//        private readonly ApplicationDbContext dbContext;

//        public OrderHistoryController()
//        {
//            dbContext = new ApplicationDbContext(); // Initialize your DbContext here
//        }

//        [Authorize]
//        public ActionResult OrderHistory()
//        {
//            // Retrieve the user's order history from the database
//            var userId = User.Identity.GetUserId();
//            var orderHistory = GetOrderHistory(userId); // Implement GetOrderHistory

//            return View(orderHistory);
//        }


//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                dbContext.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
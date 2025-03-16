using System.Web.Mvc;
using OrderProcessingApp.Models;

namespace OrderProcessingApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order/OrderEntry
        public ActionResult OrderEntry()
        {
            return View();  // Render the OrderEntry view without any data
        }

        // POST: Order/ProcessOrder
        [HttpPost]
        public ActionResult ProcessOrder(Order order)
        {
            // Flag to indicate whether input is valid
            bool isValidInput = true;

            // Check if OrderAmount is valid
            if (order.OrderAmount <= 0)
            {
                // Set flag to false, indicating invalid input
                isValidInput = false;
            }

            if (!isValidInput)
            {
                // Store the model in TempData to preserve it after redirect
                TempData["OrderData"] = order;

                // Return to OrderEntry view with the invalid model and error message
                ViewBag.ErrorMessage = "OrderAmount is not correct, please enter a valid amount.";
                return RedirectToAction("OrderEntry");  // Redirect to OrderEntry view with the invalid model
            }

            // If the input is valid, process the order
            if (order.CustomerType == "Loyal" && order.OrderAmount >= 100)
            {
                order.Discount = 0.1m * order.OrderAmount;  // 10% discount for Loyal customers with $100 or more
            }
            else
            {
                order.Discount = 0;  // No discount if not Loyal or order is less than $100
            }

            // Calculate the total amount after discount
            order.TotalAmount = order.OrderAmount - order.Discount;

            // Return the result to the OrderResult view
            return View("OrderResult", order);
        }
    }
}

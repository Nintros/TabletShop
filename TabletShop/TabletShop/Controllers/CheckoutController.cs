using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TabletShop.Models;
using TabletShopService;

namespace TabletShop.Controllers
{
	[Authorize]
    public class CheckoutController : Controller
    {
		private TabletService service = new TabletService();

		public ActionResult AddressAndPayment()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddressAndPayment(ProxyOrder proxyOrder)
		{
			Order order = proxyOrder.CloneToOrder();
			int orderId = service.AddOrder(order);
				
			var cart = ShoppingCart.GetCart(HttpContext);
			cart.CreateOrder(orderId);

			return RedirectToAction("Complete", new { id = order.OrderId });
		}

		public ActionResult Complete(int id)
		{
				return View(id);
		}
    }
}

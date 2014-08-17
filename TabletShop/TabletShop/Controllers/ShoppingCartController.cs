using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TabletShop.Models;
using TabletShop.ViewModels;
using TabletShopService;

namespace TabletShop.Controllers
{
	public class ShoppingCartController : Controller
    {
		private TabletService service = new TabletService();

		public ActionResult Index()
		{
			var cart = ShoppingCart.GetCart(this.HttpContext);

			var viewModel = new ShoppingCartViewModel
			{
				CartItems = cart.GetCartItems(),
				CartTotal = cart.GetTotal()
			};

			return View(viewModel);
		}

		public ActionResult AddToCart(int id)
		{
			var addedTablet = service.GetTablet(id);
			var cart = ShoppingCart.GetCart(HttpContext);
			cart.AddToCart(addedTablet);

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult RemoveFromCart(int id)
		{
			var cart = ShoppingCart.GetCart(HttpContext);
			string albumName = service.GetCartByRecordId(id).Tablet.Model;
			int itemCount = cart.RemoveFromCart(id);
			var results = new ShoppingCartRemoveViewModel
			{
				Message = Server.HtmlEncode(albumName) +
					" has been removed from your shopping cart.",
				CartTotal = cart.GetTotal(),
				CartCount = cart.GetCount(),
				ItemCount = itemCount,
				DeleteId = id
			};

			return Json(results);
		}

		[ChildActionOnly]
		public ActionResult CartSummary()
		{
			var cart = ShoppingCart.GetCart(this.HttpContext);

			ViewData["CartCount"] = cart.GetCount();

			return PartialView("CartSummary");
		}
    }
}

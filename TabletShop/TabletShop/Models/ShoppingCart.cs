using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TabletShop.Models
{
	using System.Web.Mvc;

	using TabletShopService;

	public class ShoppingCart
	{
		private const double VAT = 0.2;

		private TabletService service = new TabletService();
		
		private string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Tablet tablet)
        {
			Cart cartItem = service.GetCart(ShoppingCartId, tablet.TabletId);

	        if (cartItem == null)
	        {
		        cartItem = new Cart {
                    TabletId = tablet.TabletId,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DataCreated = DateTime.Now
                };

                service.AddCart(cartItem);
            }
            else
            {
	            cartItem.Count ++;
				service.EditCart(cartItem);
            }
        }
		
        public int RemoveFromCart(int id)
        {
			var cartItem = service.GetCartByRecordIdAndShppingId(ShoppingCartId, id);
			int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
					service.EditCart(cartItem);
                }
                else
                {
                    service.DeleteCart(cartItem);
                }
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = service.GetCarts(ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                service.DeleteCart(cartItem);
            }
        }

        public List<Cart> GetCartItems()
        {
            return service.GetCarts(ShoppingCartId);
        }

        public int GetCount()
        {
            int? count = (from cartItems in service.GetCarts(ShoppingCartId)
                          select (int?)cartItems.Count).Sum();

            return count ?? 0;
        }

        public double GetTotal()
        {
            double? total = (double?)(from cartItems in service.GetCarts(ShoppingCartId)
                                      select (int?)cartItems.Count * cartItems.Tablet.Price).Sum();

			double taxes = (total ?? 0) * VAT;
            return total.GetValueOrDefault() + taxes;
        }

        public int CreateOrder(int orderId)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

			foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    TabletId = item.TabletId,
					OrderId = orderId,
                    UnitPrice = item.Tablet.Price,
                    Quantity = item.Count
                };

                orderTotal += (item.Count * item.Tablet.Price);

				service.AddOrderDetail(orderDetail);

            }
            EmptyCart();
			return orderId;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string userName)
        {
            service.MigrateCart(ShoppingCartId);

        }
	}
}
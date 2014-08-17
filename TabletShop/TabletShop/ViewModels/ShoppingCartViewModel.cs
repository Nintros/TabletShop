using System.Collections.Generic;
using TabletShopService;

namespace TabletShop.ViewModels
{
	public class ShoppingCartViewModel
	{
		public List<Cart> CartItems { get; set; }

		public double CartTotal { get; set; }
	}
}
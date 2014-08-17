using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Web;

namespace TabletShopService
{
	public class TabletService : ITabletService
	{
		private LinqContractDataContext context = new LinqContractDataContext();

		public KeyValuePair<List<Tablet>, int> ReadTabletsByPage(int pageIndex, int pageSize, string filterValue, string sortExpression)
		{
			TabletShopDBManager tabletShopDbManager = new TabletShopDBManager();
			return tabletShopDbManager.ReadTabletsByPage(pageIndex, pageSize, filterValue, sortExpression);
		}

		public Tablet GetTablet(int id)
		{
			Tablet tablet = context.Tablets.ToList().First(e => e.TabletId == id);
			return tablet;
		}

		public Cart GetCart(string ShoppingCartId, int TabletId)
		{
			Cart cart = context.Carts.ToList().FirstOrDefault(e => e.CartId == ShoppingCartId && e.TabletId == TabletId);
			return cart;
		}

		public Cart GetCartByRecordIdAndShppingId(string ShoppingCartId, int RecordId)
		{
			Cart cart = context.Carts.ToList().FirstOrDefault(e => e.CartId == ShoppingCartId && e.RecordId == RecordId);
			return cart;
		}

		public Cart GetCartByRecordId(int recordId)
		{
			Cart cart = context.Carts.ToList().Single(e => e.RecordId == recordId);
			return cart;
		}

		public List<Cart> GetCarts(string ShoppingCartId)
		{
			List<Cart> cart = context.Carts.Where(e => e.CartId == ShoppingCartId).ToList();
			return cart;
		}

		public void AddCart(Cart cart)
		{
			context.Carts.InsertOnSubmit(cart);
			context.SubmitChanges();
		}

		public void EditCart(Cart cart)
		{
			var itemCart = context.Carts.First(e => e.CartId == cart.CartId);

			itemCart.Count = cart.Count;
			itemCart.DataCreated = cart.DataCreated;
			itemCart.RecordId = cart.RecordId;
			itemCart.TabletId = cart.TabletId;
			context.SubmitChanges();
		}

		public void DeleteCart(Cart cart)
		{
			var itemCart = context.Carts.First(e => e.CartId == cart.CartId);
			context.Carts.DeleteOnSubmit(itemCart);
			context.SubmitChanges();
		}

		public void AddOrderDetail(OrderDetail orderDetails)
		{
			context.OrderDetails.InsertOnSubmit(orderDetails);
			context.SubmitChanges();
		}

		public int AddOrder(Order order)
		{
			context.Orders.InsertOnSubmit(order);
			context.SubmitChanges();
			return order.OrderId;
		}

		public void MigrateCart(string id)
		{
			var carts = context.Carts.Where(e => e.CartId == id);
			foreach (var item in carts)
            {
                item.CartId = id;
            }
			context.SubmitChanges();
		}

		public Stream GetImage(string image)
		{
			FileStream fs;
			try
			{
				fs = File.OpenRead(Constants.IMAGES_PATH + image);
			}
			catch (FileNotFoundException)
			{
				fs = File.OpenRead(Constants.IMAGES_PATH + Constants.NOIMAGE);
			}
			
			WebOperationContext.Current.OutgoingResponse.ContentType = Constants.IMAGE_TYPE;
			return fs;
		}
	}
}

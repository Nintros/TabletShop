using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace TabletShopService
{
	[ServiceContract]
	public interface ITabletService
	{
		[WebGet(UriTemplate = "ReadTablets?pageIndex={pageIndex}&pageSize={pageSize}&filterValue={filterValue}&sortExpression={sortExpression}", ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		KeyValuePair<List<Tablet>, int> ReadTabletsByPage(
			int pageIndex, int pageSize, string filterValue, string sortExpression);

		[WebGet(UriTemplate = "Tablet?id={id}", ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		Tablet GetTablet(int id);

		[WebGet(UriTemplate = "Cart?ShoppingCartId={shoppingCartId}&TabletId={tabletId}", ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		Cart GetCart(string shoppingCartId, int tabletId);

		[WebGet(UriTemplate = "GetCartByRecordIdAndShppingId?ShoppingCartId={shoppingCartId}&RecordId={recordId}", ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		Cart GetCartByRecordIdAndShppingId(string shoppingCartId, int recordId);

		[WebGet(UriTemplate = "CartByRecord?RecordId={recordId}", ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		Cart GetCartByRecordId(int recordId);

		[WebGet(UriTemplate = "Carts?shoppingCartId={ShoppingCartId}", ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		List<Cart> GetCarts(string shoppingCartId);

		[OperationContract]
        [WebInvoke(UriTemplate = "MigrateCart?id={id}&userName={userName}")]
        void MigrateCart(string id, string userName);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/AddCart", ResponseFormat = WebMessageFormat.Json)]
		void AddCart(Cart cart);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/EditCart", ResponseFormat = WebMessageFormat.Json)]
		void EditCart(Cart cart);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/DeleteCart", ResponseFormat = WebMessageFormat.Json)]
		void DeleteCart(Cart cart);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/OrderDetail", ResponseFormat = WebMessageFormat.Json)]
		void AddOrderDetail(OrderDetail orderDetails);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/Order", ResponseFormat = WebMessageFormat.Json)]
		int AddOrder(Order order);

		[OperationContract]
		[WebGet(UriTemplate = "GetImage?image={image}", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
		Stream GetImage(string image);
	}
}

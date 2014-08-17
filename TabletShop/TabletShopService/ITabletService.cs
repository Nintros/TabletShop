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

		[WebGet(UriTemplate = "Cart?ShoppingCartId={ShoppingCartId}&TabletId={TabletId}", ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		Cart GetCart(string ShoppingCartId, int TabletId);

		[WebGet(UriTemplate = "GetCartByRecordIdAndShppingId?ShoppingCartId={ShoppingCartId}&RecordId={RecordId}", ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		Cart GetCartByRecordIdAndShppingId(string ShoppingCartId, int RecordId);

		[WebGet(UriTemplate = "CartByRecord?RecordId={RecordId}", ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		Cart GetCartByRecordId(int recordId);

		[WebGet(UriTemplate = "Carts?ShoppingCartId={ShoppingCartId}", ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		List<Cart> GetCarts(string ShoppingCartId);

		[OperationContract]
		[WebInvoke(UriTemplate = "MigrateCart/{id}")]
		void MigrateCart(string id);

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

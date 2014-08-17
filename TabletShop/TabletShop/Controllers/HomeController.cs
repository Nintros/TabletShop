using System.Web.Mvc;
using TabletShop.Helpers;
using TabletShopService;

namespace TabletShop.Controllers
{
	public class HomeController : Controller
	{
		private TabletService service = new TabletService();

		public ActionResult Index(int pageIndex = 0, int pageSize = 5, string filterValue = "", string sortExpression = "")
		{
			var result = service.ReadTabletsByPage(pageIndex, pageSize, filterValue, sortExpression);
			Paginator paginator = new Paginator(ViewBag, result.Value, pageIndex, pageSize);
			paginator.GeneratePaging();
			return View(result);
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult TabletDetails(int id)
		{
			Tablet tablet = service.GetTablet(id);
			return View(tablet);
		}
	}
}

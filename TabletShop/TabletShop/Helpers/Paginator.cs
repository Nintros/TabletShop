
namespace TabletShop.Helpers
{
	public class Paginator
	{
		private dynamic viewBag;

		private int countElements;

		private int pageIndex;

		private int startIndex;

		public Paginator(dynamic viewBag, int countElements, int pageIndex, int pageSize)
		{
			this.viewBag = viewBag;
			this.countElements = countElements;
			this.pageIndex = pageIndex;
			startIndex = (pageIndex + 1) * pageSize;
		}

		public void GeneratePaging()
		{
			generNextPage();
			generPrevPage();
			changeCurrPageForView();
		}

		private void generNextPage()
		{
			if (startIndex < countElements)
			{
				viewBag.NextPage = pageIndex + 1;
			}
			else
			{
				viewBag.NextPage = -1;
			}
		}

		private void generPrevPage()
		{
			if (0 < startIndex)
			{
				viewBag.PrevPage = pageIndex - 1;
			}
			else
			{
				viewBag.PrevPage = -1;
			}
		}

		private void changeCurrPageForView()
		{
			viewBag.CurrPage = pageIndex + 1;
		}
	}
}
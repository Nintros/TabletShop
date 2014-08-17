using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabletShopService
{
	public static class Constants
	{
		public const string CONNECTION_STRING = @"Data Source=FLETCHER\FLETCHER;Initial Catalog=TabletShop;Integrated Security=True";

		public const string READ_TABLETS_STORED = "Tablets_SEL_ByPage";

		public const string PARAM_PAGE_INDEX = "@pageIndex";

		public const string PARAM_PAGE_SIZE = "@pageSize";

		public const string PARAM_SORT_EXPRESSION_ = "@sortExpression";

		public const string PARAM_SERCH_VALUE = "@searchValue";

		public const string TABLETID = "TabletId";

		public const string MODEL = "Model";

		public const string PHOTO = "Photo";

		public const string DESCRIPTION = "Description";

		public const string PRICE = "Price";

		public const string RECORD_COUNT = "RecordsCount";

		public const string IMAGES_PATH = @"D:\Resources\Images\";

		public const string NOIMAGE = "noimage.jpg";

		public const string IMAGE_TYPE = "image/jpeg";
	}
}

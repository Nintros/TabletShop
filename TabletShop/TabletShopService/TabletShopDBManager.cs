using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace TabletShopService
{
	using System.Data;
	using System.Data.SqlClient;

	class TabletShopDBManager
	{
		public KeyValuePair<List<Tablet>, int> ReadTabletsByPage(int pageIndex, int pageSize, string filterValue, string sortExpression)
		{
			int count = 0;
			List<Tablet> tablets = new List<Tablet>();
			using (SqlConnection connection = new SqlConnection(Constants.CONNECTION_STRING))
			{
				using (SqlCommand tabletsByPageStored = new SqlCommand(Constants.READ_TABLETS_STORED, connection))
				{
					tabletsByPageStored.CommandType = CommandType.StoredProcedure;

					tabletsByPageStored.Parameters.Add(Constants.PARAM_PAGE_INDEX, SqlDbType.VarChar).Value = pageIndex;
					tabletsByPageStored.Parameters.Add(Constants.PARAM_PAGE_SIZE, SqlDbType.VarChar).Value = pageSize;
					tabletsByPageStored.Parameters.Add(Constants.PARAM_SORT_EXPRESSION_, SqlDbType.VarChar).Value = filterValue;
					tabletsByPageStored.Parameters.Add(Constants.PARAM_SERCH_VALUE, SqlDbType.VarChar).Value = sortExpression;

					connection.Open();
					SqlDataReader reader = tabletsByPageStored.ExecuteReader();
					while (reader.Read())
					{
						var tablet = new Tablet
							{
								TabletId = reader.GetInt32(0),
								Model = reader.GetString(1),
								Description = reader.GetString(2),
								Photo = reader.GetString(3),
								Price = reader.GetDecimal(4)
							};
						count = reader.GetInt32(5);
						tablets.Add(tablet);
					}
				}

			}

			return new KeyValuePair<List<Tablet>, int>(tablets, count);
		}
	}
}

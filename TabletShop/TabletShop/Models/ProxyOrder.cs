using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TabletShopService;

namespace TabletShop.Models
{
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	[Bind(Exclude = "OrderId")]
	public class ProxyOrder
	{
		public int OrderId { get; set; }

		[Required(ErrorMessage = "Title is required")]
		[StringLength(80)]
		public string Title { get; set; }
		
		[Required(ErrorMessage = "First Name is required")]
		[DisplayName("First Name")]
		[StringLength(20)]
		public string FirstName{ get; set; }

		[Required(ErrorMessage = "Last Name is required")]
		[DisplayName("Last Name")]
		[StringLength(20)]
		public string LastName{ get; set; }

		[Required(ErrorMessage = "Address is required")]
		[StringLength(50)]
		public string Address{ get; set; }

		[Required(ErrorMessage = "House Number is required")]
		[DisplayName("House Number")]
		public int HouseNumber{ get; set; }
		
		[Required(ErrorMessage = "Zip Code is required")]
		[DisplayName("Zip Code")]
		public int ZipCode{ get; set; }
		
		[Required(ErrorMessage = "City is required")]
		[StringLength(10)]
		public string City{ get; set; }
		
		[Required(ErrorMessage = "Email Address is required")]
		[DisplayName("Email Address")]
		[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
		ErrorMessage = "Email is is not valid.")]
		public string Email { get; set; }

		public Order CloneToOrder()
		{
			return new Order
				{
					Title = this.Title,
					FirstName = this.FirstName,
					LastName = this.LastName,
					Address = this.Address,
					HouseNumber = this.HouseNumber,
					ZipCode = this.ZipCode,
					City = this.City,
					Email = this.Email
				};
		}
	}
}
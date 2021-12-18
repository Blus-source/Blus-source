using System;
using DouceSody.Application.Common.Mappings;
using DouceSody.Domain;

namespace DouceSody.Application.Shop.Queries
{
	public class BasketItemDto : IMapFrom<BasketItem>
	{

		public string ProductName { get; set; }
		public decimal Quantity { get;  set; }
		public string Currency { get; set; }
		public decimal Price { get; set; }
	}
}


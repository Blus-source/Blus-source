using System;
using DouceSody.Application.Addresses.Queries;
using DouceSody.Application.Common.Mappings;
using DouceSody.Domain;

namespace DouceSody.Application.Shop.Queries
{
	public class ShopDto : IMapFrom<DouceSody.Domain.Shop>
	{
		public IList<AddressDto> Addresses { get; set; } = new List<AddressDto>();
		public IList<ProductDto> Products { get; set; } = new List<ProductDto>();
		public IList<BasketItemDto> Basket { get; set; } = new List<BasketItemDto>();
		public DeliveryAddresDto DeliveryAddres { get; set; } = new DeliveryAddresDto();

        public decimal TotalPurchasingItems { get; set; }

        public decimal TotalPricePurchasing { get; set; }
	}
}


using System;
using DouceSody.Application.Common.Mappings;
using DouceSody.Domain;

namespace DouceSody.Application.Addresses.Queries
{
	public class AddressDto : IMapFrom<Address>
	{
		public string Code { get; set; }

		public string Place { get; set; }

		public string Country { get; set; }
	}
}


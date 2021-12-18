using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DouceSody.Application.Addresses.Queries;
using DouceSody.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DouceSody.Application.Shop.Queries
{

    public class GetProductsQuery : IRequest<ShopDto>
    {
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ShopDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShopDto> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return new ShopDto
            {

                Basket = await _context.Basket
                    .AsNoTracking()
                    .ProjectTo<BasketItemDto>(_mapper.ConfigurationProvider)
                    //.OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken),

                Addresses = await _context.Addresses
                    .AsNoTracking()
                    .ProjectTo<AddressDto>(_mapper.ConfigurationProvider)
                    //.OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken),

                Products = await _context.Products
                    .AsNoTracking()
                    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                    //.OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}


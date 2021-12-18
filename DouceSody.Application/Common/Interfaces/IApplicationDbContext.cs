using System;
using DouceSody.Domain;
using Microsoft.EntityFrameworkCore;

namespace DouceSody.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; }

        DbSet<BasketItem> Basket { get; }

        DbSet<Address> Addresses { get; }

        DbSet<Domain.Shop> Shop { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}


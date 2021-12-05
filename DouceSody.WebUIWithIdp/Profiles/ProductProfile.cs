using System;
using AutoMapper;
using DouceSody.Domain;
using DouceSody.WebUIWithIdp.Models;

namespace DouceSody.WebUIWithIdp.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Currency, act => act.MapFrom(from => from.Currency))
                .ForMember(dest => dest.Image, act => act.MapFrom(from => from.Image))
                .ForMember(dest => dest.Name, act => act.MapFrom(from => from.Name))
                .ForMember(dest => dest.Price, act => act.MapFrom(from => from.Price))
                .ForMember(dest => dest.Quantity, act => act.MapFrom(from => from.Quantity))
                .ReverseMap();
            CreateMap<ICollection<Product>, ICollection<ProductViewModel>>().ReverseMap();
        }
       
    }
}


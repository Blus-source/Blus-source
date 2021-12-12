using System;
using AutoMapper;
using DouceSody.Domain;
using DouceSody.WebUIWithIdp.Models;

namespace DouceSody.WebUIWithIdp.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressViewModel>();
        }
    }
}


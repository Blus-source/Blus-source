using System;
using System.ComponentModel.DataAnnotations;

namespace DouceSody.Domain
{
    public class Address : Entity
    {
        [Key]
        public string Code { get; init; }

        public string Place { get; init; }

        public string Country { get; init; }

        public Address(string code, string place, string country)
        {
            Code = code;
            Place = place;
            Country = country;
        }
    }
}


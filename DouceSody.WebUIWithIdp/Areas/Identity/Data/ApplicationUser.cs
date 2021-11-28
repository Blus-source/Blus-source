using System;
using Microsoft.AspNetCore.Identity;

namespace DouceSody.WebUIWithIdp.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime BirthDay { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}


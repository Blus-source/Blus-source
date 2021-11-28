using System;
using Microsoft.AspNetCore.Identity;

namespace DouceSody.WebUIWithIdp.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime BirthDay { get; set; }

        public string? FullName { get; set; }
    }
}


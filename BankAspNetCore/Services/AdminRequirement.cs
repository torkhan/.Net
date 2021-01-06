using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAspNetCore.Services
{
    public class AdminRequirement : IAuthorizationRequirement
    {
        public string Role { get; set; }

        public AdminRequirement()
        {

        }

        public AdminRequirement(string r)
        {
            Role = r;
        }
    }
}

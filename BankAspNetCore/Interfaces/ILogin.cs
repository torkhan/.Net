using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAspNetCore.Interfaces
{
    public interface ILogin
    {
        Task<bool> Login(string mail, string password);
        Task<bool> LogOut();
        string GetName();

        string GetRole();
    }
}

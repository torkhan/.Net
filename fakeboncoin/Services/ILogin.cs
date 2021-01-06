using fakeboncoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeboncoin.Services
{
    public interface ILogin
    {
        Task<bool> Login(Utilisateur utilisateur);

        bool IsLogged();

        Task<bool> LogOut();

        string GetEmail();
    }
}

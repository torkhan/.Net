using BankAspNetCore.Interfaces;
using BankAspNetCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BankAspNetCore.Services
{
    public class LoginService : ILogin
    {
        private IHttpContextAccessor _accessor;

        public LoginService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public string GetName()
        {
            Claim claimNom = _accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (claimNom != null)
                return claimNom.Value;
            return null;
        }

        public string GetRole()
        {
            Claim claimRole = _accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            if (claimRole != null)
                return claimRole.Value;
            return null;
        }

        public async Task<bool> Login(string mail, string password)
        {
            Utilisateur u = DataDbContext.Instance.Utilisateurs.FirstOrDefault(x => x.Email == mail && x.MotDePasse == password);
            if(u != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, u.Nom+" "+u.Prenom),
                    new Claim(ClaimTypes.Role, u.Role),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await _accessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return true;
            }
            return false;
        }

        public async Task<bool> LogOut()
        {
            await _accessor.HttpContext.SignOutAsync();
            return true;
        }
    }
}

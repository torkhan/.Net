using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using fakeboncoin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace fakeboncoin.Services
{
    public class LoginService : ILogin
    {
        private IHttpContextAccessor _accessor;

        public LoginService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public async Task<bool> Login(Utilisateur utilisateur)
        {
            Utilisateur us = DataContext.Instance.Utilisateurs.FirstOrDefault(u => u.Email == utilisateur.Email && u.MotPasse == utilisateur.MotPasse);
            if (us != null)
            {
                //_accessor.HttpContext.Session.SetString("login", "ok");
                //_accessor.HttpContext.Session.SetString("email", utilisateur.Email);
                List<Claim> claims = new List<Claim>() {
                 new Claim(ClaimTypes.Email, us.Email),
                 new Claim(ClaimTypes.Role, us.Role)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await _accessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return true;
            }
            return false;
        }

        public bool IsLogged()
        {
            string logged = _accessor.HttpContext.Session.GetString("login");
            return logged == "ok";
        }

        public async Task<bool> LogOut()
        {
            //_accessor.HttpContext.Session.Clear();
            await _accessor.HttpContext.SignOutAsync();
            return true;
        }

        public string GetEmail()
        {
            //return _accessor.HttpContext.Session.GetString("email");
            Claim emailClaim = _accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            if (emailClaim != null)
                return emailClaim.Value;
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fakeboncoin.Models;
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
        public bool Login(Utilisateur utilisateur)
        {
            Utilisateur us = DataContext.Instance.Utilisateurs.FirstOrDefault(u => u.Email == utilisateur.Email && u.MotPasse == utilisateur.MotPasse);
            if(us != null)
            {
                _accessor.HttpContext.Session.SetString("login", "ok");
                _accessor.HttpContext.Session.SetString("email", utilisateur.Email);
                return true;
            }
            return false;
        }

        public bool IsLogged()
        {
            string logged = _accessor.HttpContext.Session.GetString("login");
            return logged == "ok";
        }

        public bool LogOut()
        {
            _accessor.HttpContext.Session.Clear();
            return true;
        }

        public string GetEmail()
        {
            return _accessor.HttpContext.Session.GetString("email");
        }
    }
}

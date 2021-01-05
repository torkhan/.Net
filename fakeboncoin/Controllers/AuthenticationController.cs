using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fakeboncoin.Models;
using fakeboncoin.Services;
using Microsoft.AspNetCore.Mvc;

namespace fakeboncoin.Controllers
{
    public class AuthenticationController : Controller
    {
        private ILogin _login;
        
        public AuthenticationController(ILogin login)
        {
            _login = login;
        }
        public IActionResult Login(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        public IActionResult SubmitLogin(Utilisateur utilisateur)
        {
            if(_login.Login(utilisateur))
            {
                return RedirectToAction("FormAnnonce", "Annonce");
            }
            else
            {
                return RedirectToAction("Login", "Authentication", new { message = "Erreur d'authentification"});
            }            
        }

        public IActionResult LogOut()
        {
            _login.LogOut();
            return RedirectToAction("Index", "Annonce");
        }
    }
}
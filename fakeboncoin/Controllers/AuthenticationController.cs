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

        public async Task<IActionResult> SubmitLogin(Utilisateur utilisateur)
        {
            if(await _login.Login(utilisateur))
            {
                return RedirectToAction("FormAnnonce", "Annonce");
            }
            else
            {
                return RedirectToAction("Login", "Authentication", new { message = "Erreur d'authentification"});
            }            
        }

        public async Task<IActionResult> LogOut()
        {
            await _login.LogOut();
            return RedirectToAction("Index", "Annonce");
        }
    }
}
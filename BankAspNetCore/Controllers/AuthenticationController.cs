using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAspNetCore.Interfaces;
using BankAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankAspNetCore.Controllers
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

        public async Task<IActionResult> SubmitLogin(string mail, string password)
        {
            if (await _login.Login(mail, password))
            {
                return RedirectToAction("Index", "Compte");
            }
            else
            {
                return RedirectToAction("Login", "Authentication", new { message = "Erreur d'authentification" });
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await _login.LogOut();
            return RedirectToAction("Index", "Compte");
        }
    }
}
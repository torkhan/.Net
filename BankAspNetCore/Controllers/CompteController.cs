using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAspNetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankAspNetCore.Controllers
{
    public class CompteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "admin")]
        public IActionResult Search(int numero)
        {
            return View("Index", Compte.GetCompteById(numero));
        }

        [Authorize(Policy = "admin")]
        [HttpGet]
        public IActionResult CreationCompte(string message,string type)
        {
            if(message != null && type != null)
            {
                ViewBag.Message = message;
                ViewBag.Type = type;
            }
            return View("FormCompte");
        }

        [Authorize(Policy = "admin")]
        [HttpPost]
        public IActionResult SubmitCreationCompte(Client client, decimal solde)
        {
            Compte compte = new Compte(client, solde);
            string message = "";
            string type = "";
            if(compte.Save())
            {
                type = "success";
                message = "Compte créé avec le numéro " + compte.Numero; 
            }
            else
            {
                type = "danger";
                message = "Erreur de création de compte";
            }
            return RedirectToAction("CreationCompte", new { message = message, type = type });
        }

        [Authorize(Policy = "superAdmin")]

        public IActionResult Operation(int id, string type)
        {
            ViewBag.Type = type;
            ViewBag.Numero = id;
            return View();
        }

        [Authorize(Policy = "superAdmin")]

        public IActionResult SubmitOperation(int numero, decimal montant, string type)
        {
            Compte compte = Compte.GetCompteById(numero);
            if(compte != null)
            {
                if(type == "depot")
                {
                    compte.Depot(montant);
                }
                else if(type == "retrait")
                {
                    compte.Retrait(montant);
                }
                return RedirectToAction("Search", new { numero = compte.Numero });
            }
            
            return RedirectToAction("Index");
        }
    }
}
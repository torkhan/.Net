using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoursAspNETCORE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNETCORE.Controllers
{
    public class ContactController : Controller
    {
        //Service pour récupérer les informations du Hosting
        private IWebHostEnvironment _env;
        public ContactController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            //ViewData["contacts"] = Contact.GetContacts();
            //ViewBag.Contacts = Contact.GetContacts();
            return View(Contact.GetContacts());
        }

        [HttpGet]
        public IActionResult Form(int? id)
        {
            Contact contact = null;
            if (id != null)
            {
               contact = Contact.GetContactById((int)id);
            }
            return View(contact);
        }

        private string Upload(IFormFile avatar)
        {
            string filePath = Path.Combine(_env.WebRootPath, "avatar", avatar.FileName);
            Stream stream = System.IO.File.Create(filePath);
            avatar.CopyTo(stream);
            stream.Close();
            //return Path.Combine("avatar", avatar.FileName);
            return "avatar/" + avatar.FileName;
        }
        [HttpPost]
        public IActionResult SubmitForm(Contact contact, IFormFile avatar)
        {
            if(contact.Id == 0)
            {
                contact.Avatar = Upload(avatar);
                if (contact.Save())
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Form");
                }
            }
            else
            {
                Contact.UpdateContact(contact);
                return RedirectToAction("Index");
            } 
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            return View(Contact.GetContactById(id));
        }

        public IActionResult Delete(int id)
        {
            Contact contact = Contact.GetContactById(id);
            if (contact != null)
                contact.Delete();
            return RedirectToAction("Index");
        }

        public IActionResult FormEmail(int id)
        {
            Contact contact = Contact.GetContactById(id);
            if(contact != null)
                return View(contact);
            else
                return RedirectToAction("Index");
        }

        public IActionResult SubmitEmail(Email email, int contactId)
        {
            Contact.AddMail(email, contactId);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmail(int emailId, int contactId)
        {
            Contact.RemoveMail(emailId, contactId);
            return RedirectToAction("Detail", new { id = contactId });
        }

        public IActionResult SubmitSearch(string search)
        {
            return View("Index", Contact.SearchContacts(search));
        }
    }
}
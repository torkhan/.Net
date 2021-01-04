using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using fakeboncoin.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace fakeboncoin.Controllers
{
    public class AnnonceController : Controller
    {
        private IWebHostEnvironment _env;

        public AnnonceController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index(string search)
        {
            List<Annonce> annonces = null;
            if (search != null)
                annonces = Annonce.Search(search);
            return View(annonces);
        }

        public IActionResult DetailAnnonce(int id)
        {
            ViewBag.BaseUrl = "https://localhost:44301/";
            List<Annonce> annonces = GetAnnoncesFromSession();
            ViewBag.isFavoris = annonces.Find(a => a.Id == id) != null;
            return View(Annonce.GetAnnonce(id));
        }

        public IActionResult FormAnnonce()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitFromAnnonce(Annonce annonce, IFormFile[] images)
        {
            foreach (IFormFile image in images)
            {
                annonce.Images.Add(new Image() { Url = Upload(image) });
            }
            annonce.Save();
            return RedirectToAction("Index");
        }

        private string Upload(IFormFile file)
        {
            string pathFile = Path.Combine(_env.WebRootPath, "images", file.FileName);
            Stream stream = System.IO.File.Create(pathFile);
            file.CopyTo(stream);
            stream.Close();
            return "images/" + file.FileName;
        }


        public IActionResult Favoris()
        {
            //string annoncesString = HttpContext.Session.GetString("annonces");
            //List<Annonce> annonces = (annoncesString != null)
            //        ? JsonConvert.DeserializeObject<List<Annonce>>(annoncesString)
            //        : new List<Annonce>();
            return View(GetAnnoncesFromSession());
        }

        public IActionResult AddToFavoris(int id)
        {
            Annonce a = Annonce.GetAnnonce(id);
            if (a != null)
            {
                List<Annonce> annonces = GetAnnoncesFromSession();
                annonces.Add(a);
                HttpContext.Session.SetString("annonces", JsonConvert.SerializeObject(annonces));
            }
            return RedirectToAction("Favoris");
        }


        public IActionResult RemoveFromFavoris(int id)
        {
            List<Annonce> annonces = GetAnnoncesFromSession();
            Annonce annonce = annonces.Find(a => a.Id == id);
            if (annonce != null)
            {
                annonces.Remove(annonce);
                HttpContext.Session.SetString("annonces", JsonConvert.SerializeObject(annonces));
            }
            return RedirectToAction("Favoris");
        }

        private List<Annonce> GetAnnoncesFromSession()
        {
            string annoncesString = HttpContext.Session.GetString("annonces");
            List<Annonce> annonces = (annoncesString != null)
                ? JsonConvert.DeserializeObject<List<Annonce>>(annoncesString)
                : new List<Annonce>();

            return annonces;
        }
        public IActionResult GetUrl()
        {
            return View();
        }
    }
}
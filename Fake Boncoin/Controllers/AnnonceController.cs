using Fake_Boncoin.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fake_Boncoin.Controllers
{
    public class AnnonceController : Controller
    {
        private IWebHostEnvironment _env;

        public AnnonceController (IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index(string search)
        {
            List<Annonce> annonces = null;
            if (search != null)
                annonces = Annonce.Search(search);
            return View();
        }
        public IActionResult DetailAnnonce(int id)
        {
            return View(Annonce.GetAnnonce(id));
        }
        public IActionResult FormAnnonce()
        {
            return View();
        }
        public IActionResult SubmitFormAnnonce(Annonce annonce, IFormFile[] images)
        {
            foreach(IFormFile image in images)
            {
                annonce.Images.Add(new Image() { Url = Upload(image) });
            }
            annonce.Save();
            return RedirectToAction("index");
        }
        public string Upload(IFormFile file)
        {
            string pathFile = Path.Combine(_env.WebRootPath, "images", file.FileName);
            Stream stream = System.IO.File.Create(pathFile);
            file.CopyTo(stream);
            stream.Close();
            return "images/" + file.FileName;
        }
       
    }
}

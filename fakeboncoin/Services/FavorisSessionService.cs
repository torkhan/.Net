using fakeboncoin.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeboncoin.Services
{
    public class FavorisSessionService : IFavoris
    {
        private HttpContext _httpContext;
        public FavorisSessionService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext.HttpContext;
        }
        public bool AddToFavoris(int id)
        {
            Annonce a = Annonce.GetAnnonce(id);
            if (a != null)
            {
                List<Annonce> annonces = GetFavoris();
                annonces.Add(a);
                _httpContext.Session.SetString("annonces", JsonConvert.SerializeObject(annonces));
                return true;
            }
            return false;
        }

        public bool RemoveFromFavoris(int id)
        {
            List<Annonce> annonces = GetFavoris();
            Annonce annonce = annonces.Find(a => a.Id == id);
            if (annonce != null)
            {
                annonces.Remove(annonce);
                _httpContext.Session.SetString("annonces", JsonConvert.SerializeObject(annonces));
            }
            return false;
        }

        public List<Annonce> GetFavoris()
        {
            string annoncesString = _httpContext.Session.GetString("annonces");         
            List<Annonce> annonces = (annoncesString != null)
                ? JsonConvert.DeserializeObject<List<Annonce>>(annoncesString)
                : new List<Annonce>();

            return annonces;
        }

        public bool IsFavoris(int id)
        {
            List<Annonce> annonces = GetFavoris();
            return annonces.Find(a => a.Id == id) != null;
        }
    }
}

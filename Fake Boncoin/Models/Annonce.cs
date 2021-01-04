using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fake_Boncoin.Models
{
    public class Annonce
    {
        int id;
        string titre;
        string description;
        decimal prix;
        DateTime dateCreation;

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Description { get => description; set => description = value; }
        public decimal Prix { get => prix; set => prix = value; }

        public List<Image> Images { get; set; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }

        public static List<Annonce>Search (string search)
        {   
            return new List<Annonce>
                (DataContext.Instance.Annonces
                .Include(a=>a.Images)
                .Where(a => a.Titre.Contains(search) || a.Description.Contains(search)));
        }
        public static Annonce GetAnnonce(int id)
        {
            return DataContext.Instance.Annonces.Find(id);
        }
        public bool Save()
        {
            DateCreation = DateTime.Now;
            DataContext.Instance.Annonces.Add(this);
            return DataContext.Instance.SaveChanges() > 0;
        }


        

    }
}

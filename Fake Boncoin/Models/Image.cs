using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fake_Boncoin.Models
{
    public class Image
    {
        int id;
        int annonceId;
        string url;

        public int Id { get => id; set => id = value; }
        [ForeignKey("Annonce")]
        public int AnnonceId { get => annonceId; set => annonceId = value; }
        public string Url { get => url; set => url = value; }

        public Annonce Annonce { get; set; }

       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fakeboncoin.Models
{
    public class Image
    {
        private int id;
        private int annonceId;
        private string url;

        public int Id { get => id; set => id = value; }
        
        [ForeignKey("Annonce")]
        public int AnnonceId { get => annonceId; set => annonceId = value; }
        public string Url { get => url; set => url = value; }

        public Annonce Annonce { get; set; }


    }
}

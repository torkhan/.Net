using CoursAspNETCORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursAspNETCORE.ViewModels
{
    public class ViewModelActionWithViewModel
    {
        private Personne personne;

        private List<Personne> listePersonnes;

        public List<Personne> ListePersonnes { get => listePersonnes; set => listePersonnes = value; }
        public Personne Personne { get => personne; set => personne = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAspNetCore.Models
{
    public class Utilisateur
    {
        private int id;
        private string nom;
        private string prenom;
        private string email;
        private string motDePasse;
        private string role;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public string MotDePasse { get => motDePasse; set => motDePasse = value; }
        public string Role { get => role; set => role = value; }
    }
}

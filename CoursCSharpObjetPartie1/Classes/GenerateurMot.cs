using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    public class GenerateurMot : IGenerateur
    {
        private string[] mots = new string[] { "amazon", "google", "facebook", "microsoft" };

        public string Generer()
        {
            Random r = new Random();
            int randomIndex = r.Next(mots.Length);
            return mots[randomIndex];
        }
    }
}

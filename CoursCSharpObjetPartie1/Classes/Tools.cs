using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CoursCSharpObjetPartie1.Classes
{
    public class Tools
    {
        public bool IsBissextile(int annee)
        {
            //if(annee%4 == 0)
            //{
            //    if(annee%100 == 0 && annee%400 != 0)
            //    {
            //        return false;
            //    }
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return (annee % 4 == 0 && !(annee % 100 == 0 && annee % 400 != 0));
        }

        public int WordWount(string chaine)
        {
            int nbre = 0;
            if(chaine != "")
            {
                chaine = chaine.Trim();
                string[] words = chaine.Split(' ');            
                nbre = words.Length;
                string pattern = @"^(!|\.|,|;|\?|:|\^)+$";
                foreach(string w in words)
                {
                    if(Regex.IsMatch(w, pattern))
                    {
                        nbre--;
                    }
                }
            }
            return nbre;
        }
    }
}

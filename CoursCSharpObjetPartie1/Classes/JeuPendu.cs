using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    public class JeuPendu
    {
        private IGenerateur generateur;
        private string motATrouve;
        private int nbreEssai;
        private string masque;
        public JeuPendu(IGenerateur g)
        {
            generateur = g;
            motATrouve = g.Generer();
            nbreEssai = 10;
        }

        public JeuPendu(IGenerateur g, int n) : this(g)
        {
            nbreEssai = n;
        }

        public int NbreEssai { get => nbreEssai; }
        public string Masque { get => masque; }

        public bool TestChar(char c)
        {
            bool found = false;
            string tmpMasque = "";
            for(int i=0; i < motATrouve.Length; i++)
            {
                if(motATrouve[i] == c)
                {
                    found = true;
                    tmpMasque += c;
                }
                else
                {
                    tmpMasque += masque[i];
                }
            }
            masque = tmpMasque;
            if(found == false)
            {
                nbreEssai--;
            }
            return found;
        }

        public bool TestWin()
        {
            //if(motATrouve == masque && nbreEssai > 0)
            //{
            //    return true;
            //}
            //return false;
            return (motATrouve == masque && nbreEssai > 0);
        }

        public void GenererMasque()
        {
            masque = "";
            for(int i=0; i < motATrouve.Length; i++)
            {
                masque += "*";
            }
        }
    }
}

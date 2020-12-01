using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire
{
    class ComptePayant : CompteBancaire
    {
        public ComptePayant(decimal solde, int code) : base(solde, code)
        {
        }
    }
}

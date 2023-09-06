using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opak3ITA
{
    public class MasovyVrah
    {

        protected uint pocetObeti;
        protected string zpusobVrazd;
        protected string jmeno;
        protected bool je;

        public MasovyVrah(uint pocetObeti, string zpusobVrazd, string jmeno, bool je)
        {
            this.pocetObeti = pocetObeti;
            this.zpusobVrazd = zpusobVrazd;
            this.jmeno = jmeno;
            this.je = je;
        }
        public override string ToString()
        {
            return $"{jmeno} zabil {pocetObeti} a to způsobem: {zpusobVrazd} ({(je ? "Je" : "Neni")})";
        }

    }
}

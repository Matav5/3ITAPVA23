using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ITARestauraceOpak
{
    internal class Produkt
    {
        public uint cena;
        public string nazev;
        public bool jeLegalni;

        public Produkt(uint cena, string nazev, bool jeLegalni)
        {
            this.cena = cena;
            this.nazev = nazev;
            this.jeLegalni = jeLegalni;
        }
    }
}

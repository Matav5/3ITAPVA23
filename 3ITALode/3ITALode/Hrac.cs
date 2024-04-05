using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ITALode
{
    public class Hrac
    {
        public string Prezdivka { get; private set; }
        public Policko[,] HerniPole { get; private set; }

        public bool JeReadyNaBitvu => HerniPole.Cast<Policko>().Count((x) => x.Lod != null) >= 5;
        public Hrac(string Prezdivka)
        {
            this.Prezdivka = Prezdivka;
            this.HerniPole = new Policko[10, 10];
        }
    }
}

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
        public Label Label { get; private set; }

        public Hrac(string Prezdivka, Label label)
        {
            this.Prezdivka = Prezdivka;
            this.HerniPole = new Policko[10, 10];
            this.Label = label;
            this.Label.Text = Prezdivka;
        }
    }
}

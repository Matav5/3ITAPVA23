using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ITARestauraceOpak
{
    internal class Restaurace
    {
        public uint pocetZakazniku = 0;
        public string nazev;
        public string jmenoKuchare;
        public List<Produkt> seznamProduktu;
        public int zisk = 100;
        public uint kapacitaZakazniku;

        public Restaurace(string nazev, string jmenoKuchare, List<Produkt> seznamProduktu, uint kapacitaZakazniku)
        {
            this.nazev = nazev;
            this.jmenoKuchare = jmenoKuchare;
            this.seznamProduktu = seznamProduktu;
            this.kapacitaZakazniku = kapacitaZakazniku;
        }

        public void ProdejProdukt(string nazevProduktu) {
            if (pocetZakazniku <= 0)
                return;

            Produkt nalezenyProdukt =  seznamProduktu.Find(produkt => produkt.nazev == nazevProduktu);
            
            if (nalezenyProdukt == null)
                return;

            zisk += (int) nalezenyProdukt.cena;
            pocetZakazniku--;

            if (!nalezenyProdukt.jeLegalni)
            {
                // Random.Shared.Next()
                Random r = new Random();
                if(r.Next(1,101) < 30)
                {
                    //Prohrál
                    Prohra();
                }
            }
        }

        private void Prohra()
        {
            MessageBox.Show($"Prohrál jsi chytli tě federálové." +
                $" Loss Hermanoss, tvůj finální výdělek je {zisk}", "Prohrál jsi");
            Application.Exit();
        }

        internal void OdeberZisk()
        {
            zisk -= 30;
            if(zisk < 0)
            {

                MessageBox.Show("Bankrot. Skill Issue", "Prohrál jsi!");
                Application.Exit();
            }
        }

        internal void PridejZakaznika()
        {
            pocetZakazniku++;
            if(pocetZakazniku > kapacitaZakazniku)
            {
                MessageBox.Show("Máš víc zakazníků než je kapacita. Špatnej Business man ty být", "Prohrál jsi!");
                Application.Exit();
            }
        }
    }
}

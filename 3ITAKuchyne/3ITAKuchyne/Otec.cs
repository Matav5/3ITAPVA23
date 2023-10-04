using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ITAKuchyne
{
    internal class Otec
    {
        float promileVKrvi;
        float agreseVKrvi;

        public Otec(float promileVKrvi, float agreseVKrvi)
        {
            this.promileVKrvi = promileVKrvi;
            this.agreseVKrvi = agreseVKrvi;
        }
        public void OnMaminkaDovarila(Maminka maminka)
        {
            Random rnd = new Random();
            if(rnd.Next(100) < agreseVKrvi)
            {
                Console.WriteLine("Otec se vrátil domů a zrušil kuchyň.");
            }
            Console.WriteLine("Otec s "+promileVKrvi+" promile v krvi přišel a dal si večeři");
        }
    }
}

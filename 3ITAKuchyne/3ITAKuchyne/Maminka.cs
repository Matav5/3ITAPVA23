using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ITAKuchyne
{
    internal class Maminka
    {
        float delkaVareni;
        string pokrm;
        bool staleVari;
        public Action<Maminka> OnMaminkaUvarila;

        public Maminka(float delkaVareni, string pokrm, bool staleVari)
        {
            this.delkaVareni = delkaVareni;
            this.pokrm = pokrm;
            this.staleVari = staleVari;
        }
        public void ZacniVarit()
        {
            staleVari = true;
            Thread.Sleep((int)(delkaVareni * 1000));
            Console.WriteLine("Maminka uvařila večeri. Je to její úžasný " + pokrm);
            if(OnMaminkaUvarila != null)
                OnMaminkaUvarila(this);
        }
    }
}

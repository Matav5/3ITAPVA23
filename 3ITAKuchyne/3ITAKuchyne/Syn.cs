using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ITAKuchyne
{
    internal class Syn
    {
        string jmeno;
        float hlad;
        int loseStreak;
        bool jePlnej;

        public Syn(string jmeno, float hlad, int loseStreak)
        {
            this.jmeno = jmeno;
            this.hlad = hlad;
            this.loseStreak = loseStreak;
            this.jePlnej = hlad <= 0;
        }
        public void OnMaminkaUvarila(Maminka maminka)
        {
            Console.WriteLine(jmeno +" se šel najíst!");
            hlad -= 25;
            jePlnej = hlad <= 0;

            if (!jePlnej)
            {
                if(loseStreak > 3)
                {
                    Console.WriteLine("Syn vzal stůl a rozmlátil kuchyň");
                }

                Console.WriteLine("Syn okřikl maminku ať mu jde znova uvařit");
                maminka.ZacniVarit();
            }
            else
            {
                maminka.OnMaminkaUvarila -= OnMaminkaUvarila;
            }
        }
    }
}

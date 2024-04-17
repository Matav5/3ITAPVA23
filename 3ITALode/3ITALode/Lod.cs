using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _3ITALode
{
    public class Lod
    {
        public int Velikost { get; private set; }

        public Vector2 Smer { get; private set; }

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Zasahy { get; private set; }
        public bool JePotopena => Zasahy >= Velikost;

        public event Action<Lod> OnLodPotopena;


        public Lod(int Velikost, Vector2 Smer, int X, int Y, int Zasahy)
        {
            this.Velikost = Velikost;
            this.Smer = Smer;
            this.X = X;
            this.Y = Y;
            this.Zasahy = Zasahy;
        }
        public void Zasah()
        {
            Zasahy++;
            //Pokud je potopena... dá vědět ostatním
            if (JePotopena)
                OnLodPotopena?.Invoke(this);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ITACukrKavaLimonada
{
    internal class Lidicky
    {
        private bool jeNazivu;
        private float x;
        private float y;
        private bool jeVitez;
        private bool bezi;
        private float rychlost;

        public Lidicky(bool jeNazivu,int x, int y, float rychlost)
        {
            this.jeNazivu = jeNazivu;
            this.x = x;
            this.y = y;
            this.rychlost = rychlost;
        }
        public void Vykresli(Graphics g)
        {
            if (jeNazivu)
            {
                g.FillEllipse(Brushes.Blue, x, y, 10, 10);
            }
            else
            {
                g.FillEllipse(Brushes.Red, x, y, 10, 14);
            }
        }
        public void Pohni()
        {
            x += rychlost;
        }

    }
}

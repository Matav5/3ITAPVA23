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

        public bool Bezi => bezi;
        public float X => x;
        public float Y => y;
        public Action<Lidicky> OnLidicekUmrel;
        public Action<Lidicky> OnLidicekPrezil;
        public Lidicky(bool jeNazivu,int x, int y, float rychlost)
        {
            this.jeNazivu = jeNazivu;
            this.x = x;
            this.y = y;
            this.rychlost = rychlost;
        }
        public void Vykresli(Graphics g)
        {
            if (jeVitez)
            {
                g.FillEllipse(Brushes.Lime, x, y, 10, 10);
            }
            else if (jeNazivu)
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
            if(bezi)
                x += rychlost;
        }

        internal void OnSemaforZmenilBarvu(Semafor semafor)
        {
            if (Random.Shared.Next(101) <= 20)
                return;

            if (semafor.JeZeleny)
            {
                bezi = true;
            }
            else
            {
                bezi = false;
            }
        }

        internal void Vyhral()
        {
            jeVitez = true;
            bezi = false;
            if (OnLidicekPrezil != null)
                OnLidicekPrezil(this);
        }

        internal void Umri()
        {
            bezi = false;
            if(OnLidicekUmrel != null)
                OnLidicekUmrel(this);

        }
    }
}

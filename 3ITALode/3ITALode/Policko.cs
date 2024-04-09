using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3ITALode
{
    public partial class Policko : UserControl
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        //Loď na políčku
        private Lod? lod;
        public Lod? Lod { get => lod; set
            {
                lod = value;

                BackColor = lod != null ? Color.White : Color.Turquoise;
            }
        }
        public bool JeStrelena { get; private set; }

        //Vlastník políčka
        public Hrac Hrac { get; private set; }

        public event Action<Policko> OnPolickoKliknuto;

        public Policko(int X, int Y, Lod lod, Hrac hrac) : this()
        {
            this.X = X;
            this.Y = Y;
            this.Lod = lod;
            this.Hrac = hrac;
        }


        private Policko()
        {
            InitializeComponent();
        }

        private void Policko_MouseClick(object sender, MouseEventArgs e)
        {
            if(OnPolickoKliknuto != null)
                OnPolickoKliknuto.Invoke(this);
        }
        public void SchovejLod()
        {
            BackColor = Color.Turquoise;
        }

        public bool Zasah()
        {

            if(Lod != null)
            {
                BackColor = Color.DarkRed;
                JeStrelena = true;
                Lod.Zasah();
                return true;
            }
            BackColor = Color.Gray;
            return false;
        }
    }
}

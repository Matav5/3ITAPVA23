using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3ITACtverecky
{
    public partial class MultiplikacniCtverecek : Ctverecek
    {
        public MultiplikacniCtverecek()
        {
            InitializeComponent();
            Width = 200;
            Height = 200;
            BackColor = Color.Magenta;
        }

        protected override void KlikMysi(MouseEventArgs e)
        {
            Rozmnoz();
        }

        private void Rozmnoz()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    MultiplikacniCtverecek multiplikacniCtverecek = new MultiplikacniCtverecek();
                    Controls.Add(multiplikacniCtverecek);
                    multiplikacniCtverecek.Location = new Point(j * Width / 2, i * Height / 2);
                    multiplikacniCtverecek.Width = Width/2;
                    multiplikacniCtverecek.Height = Height/2;

                }
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3ITACukrKavaLimonada
{
    public partial class Semafor : UserControl
    {
        private bool jeZeleny = false;

        public bool JeZeleny => jeZeleny;
        public Action<Semafor> OnSemaforZmenilBarvu;
        public Semafor()
        {
            InitializeComponent();
        }

        private void Semafor_Paint(object sender, PaintEventArgs e)
        {
            if (jeZeleny)
            {
                e.Graphics.FillEllipse(Brushes.DarkRed, 0, 0, 100, 100);
                e.Graphics.FillEllipse(Brushes.Lime, 100, 0, 100, 100);
            }
            else
            {
                e.Graphics.FillEllipse(Brushes.HotPink, 0, 0, 100, 100);
                e.Graphics.FillEllipse(Brushes.Green, 100, 0, 100, 100);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ZmenBarvu();
        }

        public void ZmenBarvu()
        {
            jeZeleny = !jeZeleny;
            Refresh();
            // Ať jde pozorovat semafor!
            if(OnSemaforZmenilBarvu != null)
                OnSemaforZmenilBarvu(this);
        }
    }
}

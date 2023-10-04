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
    public partial class Ctverecek : UserControl
    {
        public Ctverecek()
        {
            InitializeComponent();
        }

        protected virtual void Ctverecek_MouseClick(object sender, MouseEventArgs e)
        {
            Refresh();
        }

        protected virtual void Ctverecek_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Crimson, 0, 0, Width, Height);
        }
    }
}

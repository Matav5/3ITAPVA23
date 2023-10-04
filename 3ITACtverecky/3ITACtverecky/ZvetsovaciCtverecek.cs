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
    public partial class ZvetsovaciCtverecek : Ctverecek
    {
        public ZvetsovaciCtverecek()
        {
            InitializeComponent();
        }
        protected override void Ctverecek_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Size += new Size(10, 10);
            if (e.Button == MouseButtons.Right)
                Size -= new Size(10, 10);
            base.Ctverecek_MouseClick(sender, e);
        }
        protected override void Ctverecek_Paint(object sender, PaintEventArgs e)
        {
            base.Ctverecek_Paint(sender, e);
            e.Graphics.DrawLine(new Pen(Color.Cyan, 4), 0, 0, Width, Height);
            e.Graphics.DrawLine(new Pen(Color.Cyan,4), Width, 0, 0, Height);
        }
    }
}

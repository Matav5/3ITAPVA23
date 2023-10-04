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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Ctverecek ctverecek = null;
            if (e.Button == MouseButtons.Left)
            {
                ctverecek = new VtipnyCtverecek();
            }
            else if (e.Button == MouseButtons.Right)
            {
                ctverecek = new ZvetsovaciCtverecek();
            }
            else
            {
                return;
            }
            ctverecek.Location = e.Location;
            panel1.Controls.Add(ctverecek);
            
        }
    }
}

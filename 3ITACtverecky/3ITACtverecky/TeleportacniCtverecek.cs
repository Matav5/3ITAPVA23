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
    public partial class TeleportacniCtverecek : Ctverecek
    {
        public TeleportacniCtverecek()
        {
            InitializeComponent();
            BackColor = Color.Linen;
        }

        protected override void KlikMysi(MouseEventArgs e)
        {
            Location = new Point(
                Random.Shared.Next(Parent.Width),
                Random.Shared.Next(Parent.Height)
                );
        }
    }
}

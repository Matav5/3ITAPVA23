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
    public abstract partial class Ctverecek : UserControl
    {
        public event Action<Ctverecek> OnCtverecekKlik;
        public Ctverecek()
        {
            InitializeComponent();
        }

        private void Ctverecek_MouseClick(object sender, MouseEventArgs e)
        {
            KlikMysi(e);
            if(OnCtverecekKlik != null)
                OnCtverecekKlik(this);
        }
        protected abstract void KlikMysi(MouseEventArgs e);

        public void SimulaceKlikMysi() {
            KlikMysi(null); 
        }
    }
}

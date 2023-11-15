using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3ITAPiskvorky
{
    public partial class Hra : Form
    {
        NastaveniData nastaveniData;
        bool jeProtiHraci;
        private Hra()
        {
            InitializeComponent();
        }
        public Hra(NastaveniData nastaveniData, bool jeProtiHraci) : this()
        {
            this.nastaveniData = nastaveniData;
            this.jeProtiHraci = jeProtiHraci;
        }
    }
}

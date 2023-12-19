using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3ITADoxxer
{
    public partial class Zakaznik : UserControl
    {
        string jmeno, email, adresa, cislo;
        public Zakaznik(string jmeno, string email, string adresa, string cislo )
        {
            this.jmeno = jmeno;
            this.email = email;
            this.adresa = adresa;
            this.cislo = cislo;
            UpdateUI();
        }
        private void UpdateUI()
        {
            jmenoLabel.Text = jmeno;
            emailLabel.Text = email;
            adresaLabel.Text = adresa;
            cisloLabel.Text = cislo;
        }
        private Zakaznik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

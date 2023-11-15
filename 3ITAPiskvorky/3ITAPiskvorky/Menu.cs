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
    public partial class Menu : Form
    {
        NastaveniData nastaveniData = new NastaveniData();
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hra hra = new Hra(nastaveniData,false);
            this.Hide();
            hra.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hra hra = new Hra(nastaveniData, true);
            this.Hide();
            hra.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hraješ klikáním. 5 v řadě, svisle vodorovně. Však jsi to hrál", "Pomoc");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Nastaveni nastaveni = new Nastaveni();
            this.Hide();
            nastaveni.ShowDialog();
            nastaveniData = nastaveni.NastaveniData;
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

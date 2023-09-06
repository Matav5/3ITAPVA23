using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opak3ITA
{
    public partial class VytvarecVrahu : Form
    {
        MasovyVrah masovyVrah;
        public MasovyVrah MasovyVrah => masovyVrah;
        public VytvarecVrahu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            masovyVrah = new MasovyVrah(
                (uint)numericUpDown1.Value,
                textBox1.Text,
                textBox2.Text,
                checkBox1.Checked
                );
            MessageBox.Show(masovyVrah.ToString());
            this.Close();
        }
    }
}

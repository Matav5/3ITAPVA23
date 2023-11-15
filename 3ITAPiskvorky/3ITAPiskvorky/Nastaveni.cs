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
    public partial class Nastaveni : Form
    {
        List<Image> seznamObrazku = new List<Image>()
        {
            Image.FromFile("X.png"),
            Image.FromFile("O.png"),
            Image.FromFile("Special1.png"),
            Image.FromFile("Special2.png")
        };
        int indexHrac1 = 0;
        int indexHrac2 = 1;

        public NastaveniData NastaveniData => new NastaveniData(
            pictureBox1.Image,
            pictureBox2.Image,
            trackBar2.Value,
            trackBar1.Value
            );
        public Nastaveni()
        {
            InitializeComponent();
            UpdateObrazky();
        }

        private void UpdateObrazky()
        {
            pictureBox1.Image = seznamObrazku[indexHrac1];
            pictureBox2.Image = seznamObrazku[indexHrac2];
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            label4.Text = trackBar2.Value.ToString();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            indexHrac1++;
            indexHrac1 %= seznamObrazku.Count;

            if (indexHrac1 == indexHrac2)
            {
                indexHrac1++;
            }

            //3 obrázky
            //0,1,2,0,1,2,0
            indexHrac1 %= seznamObrazku.Count;

            UpdateObrazky();
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            indexHrac2++;
            indexHrac2 %= seznamObrazku.Count;
            if (indexHrac1 == indexHrac2)
            {
                indexHrac2++;
            }

            //3 obrázky
            //0,1,2,0,1,2,0
            indexHrac2 %= seznamObrazku.Count;
            UpdateObrazky();
        }
    }

    /// <summary>
    /// Návrhový vzor Přepravka (Messenger)
    /// </summary>
    public class NastaveniData
    {
        private Image symbolHrac1;
        public Image SymbolHrac1
        {
            get => symbolHrac1;
            private set => symbolHrac1 = value;
        }

        private Image symbolHrac2;
        public Image SymbolHrac2
        {
            get => symbolHrac2;
            private set => symbolHrac2 = value;
        }

        private int vyskaPole;
        public int VyskaPole
        {
            get => vyskaPole;
            private set => vyskaPole = value;
        }

        private int sirkaPole;
        public int SirkaPole
        {
            get => sirkaPole;
            private set => sirkaPole = value;
        }

        public NastaveniData()
        {
            this.symbolHrac1 = Image.FromFile("X.png");
            this.symbolHrac2 = Image.FromFile("O.png");
            this.vyskaPole = 5;
            this.sirkaPole = 5;
        }


        public NastaveniData(Image symbolHrac1, Image symbolHrac2, int vyskaPole, int sirkaPole)
        {
            this.symbolHrac1 = symbolHrac1;
            this.symbolHrac2 = symbolHrac2;
            this.vyskaPole = vyskaPole;
            this.sirkaPole = sirkaPole;
        }
    }
}

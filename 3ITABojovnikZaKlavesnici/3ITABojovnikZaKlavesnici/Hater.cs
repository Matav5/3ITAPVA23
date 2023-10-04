using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3ITABojovnikZaKlavesnici
{
    public partial class Hater : UserControl
    {
        private string argument;

        private int pocetNapsanychPismenek;
        private Hater()
        {
            InitializeComponent();
        }
        public Hater(string argument) : this()
        {
            this.argument = argument;

            NastavLabel();
        }

        private void NastavLabel()
        {
            label1.Text = argument.Substring(pocetNapsanychPismenek);
        }
        // 2 _ _ _ _ l
        public void ZkusPismeno(char znak)
        {
            char znakArgumentu = argument[pocetNapsanychPismenek];
            if(char.ToLower(znakArgumentu) == char.ToLower(znak))
            {
                pocetNapsanychPismenek++;
                NastavLabel();
            }
            
        }
        public bool JeNazivu()
        {
            return pocetNapsanychPismenek < argument.Length;
        }
    }
}

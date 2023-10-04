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
    public partial class VtipnyCtverecek : Ctverecek
    {
        public List<string> seznamVtipu = new List<string>() {
            "Proč programátoři nemají problém s hady? Protože vědí, že je lepší nepoužívat globální proměnné.",
            "Šli dva a prostřední upadl",
            "Kolik programátorů je potřeba k výměně žárovky? Žádný, to je problém hardwaru."
        };
        public VtipnyCtverecek()
        {
            InitializeComponent();
        }
        protected override void Ctverecek_MouseClick(object sender, MouseEventArgs e)
        {
            Random r = new Random();
            int nahodnejIndex = r.Next(0, seznamVtipu.Count);
            string vtip = seznamVtipu[nahodnejIndex];
            label1.Text = vtip;
        }
    }
}

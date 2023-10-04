namespace _3ITABojovnikZaKlavesnici
{
    public partial class Form1 : Form
    {
        List<Hater> seznamHateru = new List<Hater>();
        public Form1()
        {
            InitializeComponent();
            VytvorHatery(3);
        }

        private void VytvorHatery(int pocetHateru)
        {
            string[] argumenty = File.ReadAllLines("argumenty.txt");
            for (int i = 0; i < pocetHateru; i++)
            {
                int nahodnyIndex = Random.Shared.Next(0, argumenty.Length);
                string argument = argumenty[nahodnyIndex];
                Hater hater = new Hater(argument);
                seznamHateru.Add(hater);
                flowLayoutPanel1.Controls.Add(hater);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            char znak = (char) e.KeyValue;
            for (int i = 0; i < seznamHateru.Count; i++)
            {
                seznamHateru[i].ZkusPismeno(znak);
            }
            for (int j = 0; j < seznamHateru.Count; j++)
            {
                Hater hater = seznamHateru[j];
                if (!hater.JeNazivu())
                {
                    flowLayoutPanel1.Controls.Remove(hater);
                    seznamHateru.Remove(hater);
                    j--;
                    VytvorHatery(1);
                }
                    // MessageBox.Show(znak.ToString());
            }
        }
    }
}
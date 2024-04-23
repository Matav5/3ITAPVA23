
using System.Numerics;
using System.Linq;
using System.Net.Sockets;
namespace _3ITALode
{
    public partial class Form1 : Form
    {
        Hrac hrac1;
        Hrac hrac2;

        Hrac aktualniHrac;

        public Hrac AktualniHrac
        {
            get => aktualniHrac;
            set
            {
                if(aktualniHrac != null)
                    aktualniHrac.Label.ForeColor = Color.Black;
                aktualniHrac = value;
                aktualniHrac.Label.ForeColor = Color.Red;
                //Vezme se hr�� a vizu�ln� se uk�e �e hraje
            }
        }
        public Hrac OponentHrac => aktualniHrac == hrac1 ? hrac2 : hrac1;

        private Policko _nakliknutePolicko;
        private Policko nakliknutePolicko
        {
            get => _nakliknutePolicko;
            set
            {
                if (_nakliknutePolicko != null && _nakliknutePolicko.BackColor == Color.Red)
                    _nakliknutePolicko.BackColor = Color.Turquoise;

                _nakliknutePolicko = value;
                if (_nakliknutePolicko != null)
                    _nakliknutePolicko.BackColor = Color.Red;
            }
        }
        static List<int> lodeNaStavbu = new List<int>()
        {
            5,
            4,
            3,
            3,
            2
        };

        int indexAktualniLode = 0;

        bool fazeStavby = true;
        public Form1()
        {
            InitializeComponent();

            VytvorHru("Apep","Limi�ob");
        }
        NetworkStream spojeni;

        public Form1(string jmenoHrace1, string jmenoHrace2, NetworkStream spojeni)
        {
            InitializeComponent();
            this.spojeni = spojeni;
            VytvorHru(jmenoHrace1, jmenoHrace2);

            ZacniCist();
            //Vyu��t spojen� na z�sk�v�n� a odes�l�n� tah�
            //�prava hry => neuvid�m ciz� pole a Force Click
            PosliZpravu("Ahoj");
        }

        private async void ZacniCist()
        {
            StreamReader sr = new StreamReader(spojeni);
            while (true)
            {

                string zprava = await sr.ReadLineAsync();
                MessageBox.Show(zprava);

                ZpracujZpravu(zprava);
            }
        }

        private void ZpracujZpravu(string? zprava)
        {
            // "UdelejNeco;par1;par2"
            string[] rozdelenaZprava = zprava.Split(";");
            switch (rozdelenaZprava[0])
            {
                case "Strelba":
                    StrelbaOponenta();
                    break;
                case "Stavba":
                    StavbaOponenta();
                    break;
                default:
                    break;
            }

        }

        private void StrelbaOponenta(int Y, int X)
        {

        }
        private void StavbaOponenta(int Y, int X, int Y2, int X2, int vel)
        {

        }
        private void PosliZpravu(string zprava)
        {
            StreamWriter sw = new StreamWriter(spojeni) { AutoFlush=true};
            sw.WriteLine(zprava);
        }

        private void VytvorHru(string jmenoHrace1, string jmenoHrace2)
        {
            //Vytvo�en� hr���
            hrac1 = new Hrac(jmenoHrace1, label1);
            hrac2 = new Hrac(jmenoHrace2,label2);

              AktualniHrac = Random.Shared.Next(0, 2) == 0 ? hrac1 : hrac2;
            //AktualniHrac = hrac1;
            //Vytvo�en� pol��ek
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Policko polickoHrace1 = new Policko(j, i, null, hrac1);
                    polickoHrace1.OnPolickoKliknuto += OnPolickoKliknuto;
                    hrac1.HerniPole[i, j] = polickoHrace1;
                    flowLayoutPanel1.Controls.Add(
                        polickoHrace1
                        );


                    Policko polickoHrace2 = new Policko(j, i, null, hrac2);
                    polickoHrace2.OnPolickoKliknuto += OnPolickoKliknuto;
                    hrac2.HerniPole[i, j] = polickoHrace2;
                    flowLayoutPanel2.Controls.Add(
                        polickoHrace2
                       );
                }
            }
        }
        private void OnPolickoKliknuto(Policko policko)
        {
        
            if (fazeStavby) {
                OnPolickoStavej(policko);
            }
            else
            {
                OnPolickoStrilej(policko);
            }
                //Podm�nky jestli pol��ko m��e b�t nakliknuteln�




            //St�elba => Zm�na hr��� po konci kola
            //Kontrola sest�elen�ch lod� => Checkov�n� konce hry

        }

        private void OnPolickoStrilej(Policko policko)
        {
           // MessageBox.Show(policko.ToString());
            //Prevence sebest�elby
            if (AktualniHrac == policko.Hrac)
                return;



            // Podm�nka nest��lej na st�elen� pol��ko
            if (policko.JeStrelena)
                return;

            if(!policko.Zasah())
            {
                PrepniHrace();
            }
            else
            {
                if (OponentHrac.Prohral)
                {
                    MessageBox.Show("Vyhr�l hr�� " + AktualniHrac.Prezdivka, "Konec hry");
                    Application.Restart();
                }
            }
        }

        private void OnPolickoStavej(Policko policko)
        {

            //Podm�nky stavby / Podm�nky st�elby
            if (AktualniHrac != policko.Hrac || policko.Lod != null)
                return;

            //Kontrola, �e na pol��ku neni lo� 

            if (nakliknutePolicko == null)
            {
                nakliknutePolicko = policko;
                return;
            }
            //Nesm�m kliknout na stejn� pol��ko => jinak odklik�v�m
            if (nakliknutePolicko == policko)
            {
                nakliknutePolicko = null;
                return;
            }
            //Vezmu ob� pol��ka zjist�m sm�r
            int smerX = policko.X - nakliknutePolicko.X;
            int smerY = policko.Y - nakliknutePolicko.Y;
            if (Math.Abs(smerX) + Math.Abs(smerY) > 1)
            {
                MessageBox.Show("AAAAAAAAAAAAAAAAAAAAAAAAAA");
                return;
            }

            Point zacatekLode = new Point(nakliknutePolicko.X, nakliknutePolicko.Y);

            int aktualniLod = lodeNaStavbu[indexAktualniLode];

            for (int i = 0; i < aktualniLod; i++)
            {
                //Zjist�m jestli se lo� vejde
                if (zacatekLode.X < 0 ||
                    zacatekLode.X >= AktualniHrac.HerniPole.GetLength(1) ||
                    zacatekLode.Y < 0 ||
                    zacatekLode.Y >= AktualniHrac.HerniPole.GetLength(0))
                {
                    MessageBox.Show(" IT WONT FIT ");
                    return;
                }

                //Zjist�m jestli se nenach�z� v cest� jin� lo�
                if (AktualniHrac.HerniPole[zacatekLode.Y, zacatekLode.X].Lod != null)
                {
                    MessageBox.Show("JE TAM LO�");
                    return;
                }
                zacatekLode.Offset(smerX, smerY);
                //     MessageBox.Show(zacatekLode.ToString());
            }


            //Polo��m lo�
            zacatekLode = new Point(nakliknutePolicko.X, nakliknutePolicko.Y);
            Lod lod = new Lod(aktualniLod, new Vector2(smerX, smerY), zacatekLode.X, zacatekLode.Y, 0);
            for (int i = 0; i < aktualniLod; i++)
            {
                AktualniHrac.HerniPole[zacatekLode.Y, zacatekLode.X].Lod = lod;
                zacatekLode.Offset(smerX, smerY);
            }

            indexAktualniLode++;
            nakliknutePolicko = null;
            panel1.Refresh();

            if (indexAktualniLode >= lodeNaStavbu.Count)
            {
                foreach (Policko polecko in AktualniHrac.HerniPole)
                {
                    polecko.SchovejLod();
                }
                indexAktualniLode = 0;


                if (hrac1.JeReadyNaBitvu && hrac2.JeReadyNaBitvu)
                {
                    MessageBox.Show("Jsou ready");
                    SpustBitvu();
                }
                PrepniHrace();
            }


        }

        private void SpustBitvu()
        {
            //U� nestav�me => st��l�me
            fazeStavby = false;
            panel1.Hide();
        }

        private void PrepniHrace()
        {
            AktualniHrac = AktualniHrac == hrac1 ? hrac2 : hrac1;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int index = indexAktualniLode > 4 ? 0 : indexAktualniLode;
            for (int i = 0; i < lodeNaStavbu[index]; i++)
            {
                e.Graphics.FillRectangle(Brushes.Black, i * 50, 0, 50, 50);
                e.Graphics.DrawRectangle(Pens.Gray, i * 50, 0, 50, 50);
            }
        }
    }
}


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
                //Vezme se hráè a vizuálnì se ukáže že hraje
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

            VytvorHru("Apep","Limiøob");
        }
        NetworkStream spojeni;

        public Form1(string jmenoHrace1, string jmenoHrace2, NetworkStream spojeni)
        {
            InitializeComponent();
            this.spojeni = spojeni;
            VytvorHru(jmenoHrace1, jmenoHrace2);

            ZacniCist();
            //Využít spojení na získávání a odesílání tahù
            //Úprava hry => neuvidím cizí pole a Force Click
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
            //Vytvoøení hráèù
            hrac1 = new Hrac(jmenoHrace1, label1);
            hrac2 = new Hrac(jmenoHrace2,label2);

              AktualniHrac = Random.Shared.Next(0, 2) == 0 ? hrac1 : hrac2;
            //AktualniHrac = hrac1;
            //Vytvoøení políèek
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
                //Podmínky jestli políèko mùže být nakliknutelný




            //Støelba => Zmìna hráèù po konci kola
            //Kontrola sestøelených lodí => Checkování konce hry

        }

        private void OnPolickoStrilej(Policko policko)
        {
           // MessageBox.Show(policko.ToString());
            //Prevence sebestøelby
            if (AktualniHrac == policko.Hrac)
                return;



            // Podmínka nestøílej na støelený políèko
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
                    MessageBox.Show("Vyhrál hráè " + AktualniHrac.Prezdivka, "Konec hry");
                    Application.Restart();
                }
            }
        }

        private void OnPolickoStavej(Policko policko)
        {

            //Podmínky stavby / Podmínky støelby
            if (AktualniHrac != policko.Hrac || policko.Lod != null)
                return;

            //Kontrola, že na políèku neni loï 

            if (nakliknutePolicko == null)
            {
                nakliknutePolicko = policko;
                return;
            }
            //Nesmím kliknout na stejné políèko => jinak odklikávám
            if (nakliknutePolicko == policko)
            {
                nakliknutePolicko = null;
                return;
            }
            //Vezmu obì políèka zjistím smìr
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
                //Zjistím jestli se loï vejde
                if (zacatekLode.X < 0 ||
                    zacatekLode.X >= AktualniHrac.HerniPole.GetLength(1) ||
                    zacatekLode.Y < 0 ||
                    zacatekLode.Y >= AktualniHrac.HerniPole.GetLength(0))
                {
                    MessageBox.Show(" IT WONT FIT ");
                    return;
                }

                //Zjistím jestli se nenachází v cestì jiná loï
                if (AktualniHrac.HerniPole[zacatekLode.Y, zacatekLode.X].Lod != null)
                {
                    MessageBox.Show("JE TAM LOÏ");
                    return;
                }
                zacatekLode.Offset(smerX, smerY);
                //     MessageBox.Show(zacatekLode.ToString());
            }


            //Položím loï
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
            //Už nestavíme => støílíme
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

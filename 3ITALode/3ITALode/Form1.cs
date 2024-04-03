
using System.Numerics;

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
                aktualniHrac = value;
                //Vezme se hráè a vizuálnì se ukáže že hraje
            }
        }

        private Policko _nakliknutePolicko;
        private Policko nakliknutePolicko
        {
            get => _nakliknutePolicko;
            set
            {
                if (_nakliknutePolicko != null && _nakliknutePolicko.BackColor == Color.Red)
                    _nakliknutePolicko.BackColor = Color.Turquoise;

                _nakliknutePolicko = value;
                if(_nakliknutePolicko != null)
                    _nakliknutePolicko.BackColor = Color.Red;
            }
        }
        static List<int> lodeNaStavbu = new List<int>()
        {
            2,
            3,
            3,
            4,
            5
        };
        public Form1()
        {
            InitializeComponent();

            VytvorHru();
        }

        private void VytvorHru()
        {
            //Vytvoøení hráèù
            hrac1 = new Hrac("Apep");
            hrac2 = new Hrac("Limiøob");

            //  AktualniHrac = Random.Shared.Next(0, 2) == 0 ? hrac1 : hrac2;
            AktualniHrac = hrac1;
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
            for (int i = 0; i < 5; i++)
            {
                //Zjistím jestli se loï vejde
                if (zacatekLode.X < 0 ||
                    zacatekLode.X >= AktualniHrac.HerniPole.Length ||
                    zacatekLode.Y < 0 ||
                    zacatekLode.Y >= AktualniHrac.HerniPole.Length)
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
            Lod lod = new Lod(5, new Vector2(smerX, smerY), zacatekLode.X, zacatekLode.Y, 0);
            for (int i = 0; i < 5; i++)
            {
                AktualniHrac.HerniPole[zacatekLode.Y, zacatekLode.X].Lod = lod;
                zacatekLode.Offset(smerX, smerY);
            }


            nakliknutePolicko = null;


            //Podmínky jestli políèko mùže být nakliknutelný




            //Støelba => Zmìna hráèù po konci kola
            //Kontrola sestøelených lodí => Checkování konce hry

        }
    }
}

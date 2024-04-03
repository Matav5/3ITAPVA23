
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
                //Vezme se hr�� a vizu�ln� se uk�e �e hraje
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
            //Vytvo�en� hr���
            hrac1 = new Hrac("Apep");
            hrac2 = new Hrac("Limi�ob");

            //  AktualniHrac = Random.Shared.Next(0, 2) == 0 ? hrac1 : hrac2;
            AktualniHrac = hrac1;
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
            for (int i = 0; i < 5; i++)
            {
                //Zjist�m jestli se lo� vejde
                if (zacatekLode.X < 0 ||
                    zacatekLode.X >= AktualniHrac.HerniPole.Length ||
                    zacatekLode.Y < 0 ||
                    zacatekLode.Y >= AktualniHrac.HerniPole.Length)
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
            Lod lod = new Lod(5, new Vector2(smerX, smerY), zacatekLode.X, zacatekLode.Y, 0);
            for (int i = 0; i < 5; i++)
            {
                AktualniHrac.HerniPole[zacatekLode.Y, zacatekLode.X].Lod = lod;
                zacatekLode.Offset(smerX, smerY);
            }


            nakliknutePolicko = null;


            //Podm�nky jestli pol��ko m��e b�t nakliknuteln�




            //St�elba => Zm�na hr��� po konci kola
            //Kontrola sest�elen�ch lod� => Checkov�n� konce hry

        }
    }
}

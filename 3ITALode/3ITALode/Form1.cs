
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

        private Policko nakliknutePolicko = null;
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

            AktualniHrac = Random.Shared.Next(0, 2) == 0 ? hrac1 : hrac2;

            //Vytvo�en� pol��ek
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Policko polickoHrace1 = new Policko(j, i, null, hrac1);
                    polickoHrace1.OnPolickoKliknuto += OnPolickoKliknuto;

                    flowLayoutPanel1.Controls.Add(
                        polickoHrace1
                        );
                    Policko polickoHrace2 = new Policko(j, i, null, hrac2);
                    polickoHrace2.OnPolickoKliknuto += OnPolickoKliknuto;

                    flowLayoutPanel2.Controls.Add(
                        polickoHrace2
                       );
                }
            }
        }
        private void OnPolickoKliknuto(Policko policko)
        {
            //Podm�nky stavby / Podm�nky st�elby
            if (AktualniHrac != policko.Hrac)
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
            if(Math.Abs(smerX) + Math.Abs(smerY) > 1)
            {
                MessageBox.Show("AAAAAAAAAAAAAAAAAAAAAAAAAA");
                return;
            }

            Point zacatekLode = new Point(nakliknutePolicko.X, nakliknutePolicko.Y);
            for (int i = 0; i < 1; i++)
            {
                zacatekLode.Offset(smerX, smerY);
                MessageBox.Show(zacatekLode.ToString());
            }
            //Zjist�m jestli se lo� vejde
            //Zjist�m jestli se nenach�z� v cest� jin� lo�

            //Polo��m lo�




            //Podm�nky jestli pol��ko m��e b�t nakliknuteln�




            //St�elba => Zm�na hr��� po konci kola
            //Kontrola sest�elen�ch lod� => Checkov�n� konce hry

        }
    }
}


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

        private Policko nakliknutePolicko = null;
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

            AktualniHrac = Random.Shared.Next(0, 2) == 0 ? hrac1 : hrac2;

            //Vytvoøení políèek
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
            //Podmínky stavby / Podmínky støelby
            if (AktualniHrac != policko.Hrac)
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
            //Zjistím jestli se loï vejde
            //Zjistím jestli se nenachází v cestì jiná loï

            //Položím loï




            //Podmínky jestli políèko mùže být nakliknutelný




            //Støelba => Zmìna hráèù po konci kola
            //Kontrola sestøelených lodí => Checkování konce hry

        }
    }
}

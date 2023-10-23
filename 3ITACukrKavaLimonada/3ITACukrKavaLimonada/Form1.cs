namespace _3ITACukrKavaLimonada
{
    public partial class Form1 : Form
    {
        List<Lidicky> seznamLidicek = new List<Lidicky>();
        List<Point> seznamMastnejchFleku = new List<Point>();
        int pocetMrtvych = 0;
        int pocetPrezivsich = 0;
        int pocetLidicek = 0;
        public Form1()
        {
            InitializeComponent();
            VytvorLidicky();
        }

        private void VytvorLidicky()
        {
            for (int i = 0; i < 100; i++)
            {
                Lidicky lidicek = new Lidicky(true, 
                    10,
                    Random.Shared.Next(pictureBox1.Height),
                    Random.Shared.Next(1000,3001) / 1000f
                    );
                pocetLidicek++;
                semafor1.OnSemaforZmenilBarvu += lidicek.OnSemaforZmenilBarvu;
                lidicek.OnLidicekUmrel += OnLidicekZemrel;
                lidicek.OnLidicekPrezil += OnLidicekPrezil;
                seznamLidicek.Add(lidicek);
            }
        }

        private void OnLidicekPrezil(Lidicky obj)
        {
            pocetPrezivsich++;
            label2.Text = $"Poèet pøeživších: {pocetPrezivsich}";
            ZkontrolujKonec();
        }

        private void OnLidicekZemrel(Lidicky lidicek)
        {
            pocetMrtvych++;
            label1.Text = $"Poèet mrtvých: {pocetMrtvych}";
            ZkontrolujKonec();
        }

        private void ZkontrolujKonec()
        {
            if(pocetMrtvych + pocetPrezivsich >= pocetLidicek)
            {

                timer1.Stop();
                Application.Restart();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Lidicky lidicek in seznamLidicek)
            {
                lidicek.Vykresli(e.Graphics);
            }
            foreach (Point poziceFleku in seznamMastnejchFleku)
            {
                e.Graphics.FillEllipse(Brushes.Red, poziceFleku.X, poziceFleku.Y, 10, 14);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Lidicky lidicek;
            for(int i = 0; i < seznamLidicek.Count; i++ )
            {
                lidicek = seznamLidicek[i];
                lidicek.Pohni();
                if (!semafor1.JeZeleny)
                {
                    if (lidicek.Bezi)
                    {
                        lidicek.Umri();
                        seznamLidicek.Remove(lidicek);
                        seznamMastnejchFleku.Add(new Point(
                            (int)lidicek.X,
                            (int)lidicek.Y
                            ));
                        i--;
                    }
                }
                else
                {
                    if(lidicek.X > 300)
                    {
                        lidicek.Vyhral();
                        semafor1.OnSemaforZmenilBarvu -= lidicek.OnSemaforZmenilBarvu;
                    }
                }
            }
            Refresh();
        }
    }
}
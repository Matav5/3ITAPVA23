namespace _3ITACukrKavaLimonada
{
    public partial class Form1 : Form
    {
        List<Lidicky> seznamLidicek = new List<Lidicky>();
        public Form1()
        {
            InitializeComponent();
            VytvorLidicky();
        }

        private void VytvorLidicky()
        {
            for (int i = 0; i < 25; i++)
            {
                Lidicky lidicek = new Lidicky(true, 
                    10,
                    Random.Shared.Next(pictureBox1.Height),
                    Random.Shared.Next(1000,3001) / 1000f
                    );
                seznamLidicek.Add(lidicek);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Lidicky lidicek in seznamLidicek)
            {
                lidicek.Vykresli(e.Graphics);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Lidicky lidicek in seznamLidicek)
            {
                lidicek.Pohni();
            }
            Refresh();
        }
    }
}
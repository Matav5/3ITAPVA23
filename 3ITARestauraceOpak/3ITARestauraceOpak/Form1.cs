namespace _3ITARestauraceOpak
{
    public partial class Form1 : Form
    {
        Restaurace restaurace;

        public Form1()
        {
            InitializeComponent();
            List<Produkt> menu = new List<Produkt>()
            {
                new Produkt(25, "Los Pollos", true),
                new Produkt(200, "Los Pollos Special", false)
            };
            restaurace = new Restaurace("Los Pollos Hermanos �.n.L.", "Walter B�k", menu, 25);
            NastavGrafiku();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            restaurace.ProdejProdukt("Los Pollos");
            NastavGrafiku();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            restaurace.ProdejProdukt("Los Pollos Special");
            NastavGrafiku();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            restaurace.PridejZakaznika();
            restaurace.OdeberZisk();
            NastavGrafiku();
        }

        private void NastavGrafiku()
        {
            label1.Text = $"Z�kazn�ci: {restaurace.pocetZakazniku}/{restaurace.kapacitaZakazniku}";
            label2.Text = $"Pen�ze: {restaurace.zisk}K�";
        }
    }
}
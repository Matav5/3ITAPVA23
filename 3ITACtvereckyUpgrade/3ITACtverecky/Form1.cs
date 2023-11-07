namespace _3ITACtverecky
{
    public partial class Form1 : Form
    {
        public event Action OnTlacitkoZaktivovano;
        private int pocetKliknuti = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Ctverecek ctverecek;
            if (e.Button == MouseButtons.Left)
            {
                ctverecek = new MultiplikacniCtverecek();
                
            }
            else 
            {
                ctverecek = new TeleportacniCtverecek();
            }

            panel1.Controls.Add(ctverecek);
            ctverecek.Location = e.Location;
            OnTlacitkoZaktivovano += ctverecek.SimulaceKlikMysi;
            ctverecek.OnCtverecekKlik += Ctverecek_OnCtverecekKlik;
        }

        private void Ctverecek_OnCtverecekKlik(Ctverecek ctverecek)
        {
            pocetKliknuti++;
            label1.Text = $"Poèet kliknutí:{pocetKliknuti}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(OnTlacitkoZaktivovano != null)
                OnTlacitkoZaktivovano.Invoke();
        }
    }
}
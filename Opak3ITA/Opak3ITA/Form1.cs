namespace Opak3ITA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VytvarecVrahu vytvarecVrahu = new VytvarecVrahu();
            vytvarecVrahu.ShowDialog();
            MessageBox.Show(vytvarecVrahu.MasovyVrah.ToString());
            Label label = new Label();
            label.Text = vytvarecVrahu.MasovyVrah.ToString();
            label.Width = flowLayoutPanel1.Width;
            flowLayoutPanel1.Controls.Add(label);
        }
    }
}
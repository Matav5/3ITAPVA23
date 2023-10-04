namespace _3ITAPokladVeSlozce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            VygenerujOstrov();
        }

        private void VygenerujOstrov()
        {
            if(Directory.Exists("Ostrov"))
                Directory.Delete("Ostrov", true);

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    for (int z = 0; z < 2; z++)
                    {
                        Directory.CreateDirectory($"Ostrov\\{i}\\{j}\\{z}");
                    }
                }
            }

            string cesta = "Ostrov";
            
            while (Directory.GetDirectories(cesta).Length > 0) {
                // 5 prvků - 0 - 4
                string[] slozky = Directory.GetDirectories(cesta);
                int nahodnejIndex = Random.Shared.Next(0, slozky.Length);
                MessageBox.Show(slozky[nahodnejIndex]);
                string novaCesta = slozky[nahodnejIndex] + "→";
                Directory.Move(slozky[nahodnejIndex], novaCesta);
                cesta = novaCesta;
            }
            File.Create($"{cesta}\\poklad.poklad").Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + "\\Ostrov";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(openFileDialog1.SafeFileName == "poklad.poklad")
                {
                    MessageBox.Show("Vyhrál jsi hru. Jsi miliardář. Užij si poklad", "Vyhrál jsi");
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Jsi nicka. Nemáš prachy", "Big L");
            Application.Exit();
        }
    }
}
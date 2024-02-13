namespace _3ITAMalovani
{
    public partial class Form1 : Form
    {
        List<Point> aktualniKresba = new List<Point>();

        List<ICommand> seznamPrikazu = new List<ICommand>();

        public int prikazIndex = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                aktualniKresba.Add(e.Location);
            }
            else
            {
                if(aktualniKresba.Count > 0)
                {
                    // Vytvoøí se pøíkaz na kreslení
                    DrawCommand drawCommand = new DrawCommand(pictureBox1.CreateGraphics(),pictureBox1,new List<Point>(aktualniKresba));
                    
                    // Pøerušení øetìzce
                    if(seznamPrikazu.Count -1 != prikazIndex && seznamPrikazu.Count - 1 - prikazIndex > 0)
                    {
                        MessageBox.Show($"Poèet prvkù : {seznamPrikazu.Count - 1} ; \n Poèet prvkù k odebrání: {seznamPrikazu.Count - 1 - prikazIndex} ; \n Index: {prikazIndex}");
                        seznamPrikazu.RemoveRange(prikazIndex +1, seznamPrikazu.Count - 1 - prikazIndex);
                    }
                    //Pøidání a spuštìní pøíkazu
                    seznamPrikazu.Add(drawCommand);
                    drawCommand.Execute();
                    prikazIndex++;
                    aktualniKresba.Clear();
                }
            };  
            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Vykreslování rozdìlaného tahu
            for (int i = 0; i < aktualniKresba.Count; i++)
            {
                e.Graphics.DrawRectangle(Pens.Black, aktualniKresba[i].X, aktualniKresba[i].Y, 1, 1);
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ctrl-Z => návrat do pùvodního stavu
            if (prikazIndex == -1 || seznamPrikazu.Count == 0)
                return;
            seznamPrikazu[prikazIndex].Undo();
            prikazIndex--;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CTRL-Y => návrat do aktuálnìjšího stavu
            if (prikazIndex >= seznamPrikazu.Count-1)
                return;
            prikazIndex++;
            seznamPrikazu[prikazIndex].Execute();

        }
    }
}

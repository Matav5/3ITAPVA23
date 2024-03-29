namespace _3ITAMalovani
{
    public partial class Form1 : Form
    {
        List<Point> aktualniKresba = new List<Point>();

        CommandHistory commandHistory = new CommandHistory();
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                aktualniKresba.Add(e.Location);
            }
            else
            {
                if (aktualniKresba.Count > 0)
                {
                    // Vytvoří se příkaz na kreslení
                    DrawCommand drawCommand = new DrawCommand(pictureBox1, new List<Point>(aktualniKresba), pictureBox2.BackColor);
                    commandHistory.AddCommand(drawCommand);
                    aktualniKresba.Clear();
                }
            };
            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Vykreslování rozdělaného tahu
            Pen pero = new Pen(pictureBox2.BackColor);
            for (int i = 0; i < aktualniKresba.Count; i++)
            {
                
                e.Graphics.DrawRectangle(pero , aktualniKresba[i].X, aktualniKresba[i].Y, 1, 1);
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ctrl-Z => návrat do původního stavu
            commandHistory.Undo();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CTRL-Y => návrat do aktuálnějšího stavu
            commandHistory.Next();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ChangeColorCommand changeColorCommand = new ChangeColorCommand(pictureBox2,
                    colorDialog1.Color);
                commandHistory.AddCommand(changeColorCommand);
            }
        }
    }
}

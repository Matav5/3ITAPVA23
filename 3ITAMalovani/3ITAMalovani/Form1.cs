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
                    // Vytvo�� se p��kaz na kreslen�
                    DrawCommand drawCommand = new DrawCommand(pictureBox1.CreateGraphics(),pictureBox1,new List<Point>(aktualniKresba));
                    
                    // P�eru�en� �et�zce
                    if(seznamPrikazu.Count -1 != prikazIndex && seznamPrikazu.Count - 1 - prikazIndex > 0)
                    {
                        MessageBox.Show($"Po�et prvk� : {seznamPrikazu.Count - 1} ; \n Po�et prvk� k odebr�n�: {seznamPrikazu.Count - 1 - prikazIndex} ; \n Index: {prikazIndex}");
                        seznamPrikazu.RemoveRange(prikazIndex +1, seznamPrikazu.Count - 1 - prikazIndex);
                    }
                    //P�id�n� a spu�t�n� p��kazu
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
            // Vykreslov�n� rozd�lan�ho tahu
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
            //Ctrl-Z => n�vrat do p�vodn�ho stavu
            if (prikazIndex == -1 || seznamPrikazu.Count == 0)
                return;
            seznamPrikazu[prikazIndex].Undo();
            prikazIndex--;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CTRL-Y => n�vrat do aktu�ln�j��ho stavu
            if (prikazIndex >= seznamPrikazu.Count-1)
                return;
            prikazIndex++;
            seznamPrikazu[prikazIndex].Execute();

        }
    }
}

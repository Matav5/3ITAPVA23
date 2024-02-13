using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3ITAMalovani
{
    internal class DrawCommand : ICommand
    {

        Bitmap oldbitmap;
        Bitmap newbitmap;
        List<Point> cestaKurzoru = new List<Point>();
        PictureBox pictureBox;

        public DrawCommand(PictureBox pictureBox, List<Point> cestaKurzoru, Color barvicka)
        {
            this.pictureBox = pictureBox;
         
            //Vytvoří se obrázek toho co je v pozadí PictureBoxu
            this.oldbitmap = new Bitmap(pictureBox.DisplayRectangle.Width, pictureBox.DisplayRectangle.Height);
            if (pictureBox.BackgroundImage != null)
                this.oldbitmap = (Bitmap)pictureBox.BackgroundImage.Clone();

            //Vytvoří se NOVÝ obrázek toho co je v pozadí PictureBoxu
            this.newbitmap = (Bitmap)oldbitmap.Clone();
            var actualG = Graphics.FromImage(newbitmap);

            Pen pero = new Pen(barvicka);
            // Cyklus a pro každý bodík kde kurzor => nakresli pixel do NOVÉHO obrázku
            for (int i = 0; i < cestaKurzoru.Count; i++)
            {
                actualG.DrawRectangle(pero, cestaKurzoru[i].X, cestaKurzoru[i].Y, 1, 1);
            }
            this.cestaKurzoru = cestaKurzoru;
        }

        public void Execute()
        {
            pictureBox.BackgroundImage = newbitmap;
            pictureBox.Refresh();
        }

        public void Undo()
        {
            pictureBox.BackgroundImage = oldbitmap;
            pictureBox.Refresh();
        }
    }
}

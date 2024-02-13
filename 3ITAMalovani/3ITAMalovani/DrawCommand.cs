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

        public DrawCommand(Graphics g, PictureBox pictureBox, List<Point> cestaKurzoru)
        {
            this.pictureBox = pictureBox;
         
            //Vytvoří se obrázek toho co je v pozadí PictureBoxu
            this.oldbitmap = new Bitmap(pictureBox.DisplayRectangle.Width, pictureBox.DisplayRectangle.Height);
            if (pictureBox.BackgroundImage != null)
                this.oldbitmap = (Bitmap)pictureBox.BackgroundImage.Clone();

            //Vytvoří se NOVÝ obrázek toho co je v pozadí PictureBoxu
            this.newbitmap = (Bitmap)oldbitmap.Clone();
            var actualG = Graphics.FromImage(newbitmap);
            // Cyklus a pro každý bodík kde kurzor => nakresli pixel do NOVÉHO obrázku
            for (int i = 0; i < cestaKurzoru.Count; i++)
            {
                actualG.DrawRectangle(Pens.Black, cestaKurzoru[i].X, cestaKurzoru[i].Y, 1, 1);
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

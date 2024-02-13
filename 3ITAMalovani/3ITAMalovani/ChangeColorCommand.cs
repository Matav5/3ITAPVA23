using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ITAMalovani
{
    internal class ChangeColorCommand : ICommand
    {
        Color novaBarva;
        Color staraBarva;
        Control prvek;
        public ChangeColorCommand(Control prvek, Color novaBarva)
        {
            this.prvek = prvek;
            this.novaBarva = novaBarva;
            this.staraBarva = prvek.BackColor;
        }

        public void Execute()
        {
            prvek.BackColor = novaBarva;
        }

        public void Undo()
        {
            prvek.BackColor = staraBarva;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ITAMalovani
{
    internal class CommandHistory
    {
        private List<ICommand> commands = new List<ICommand>();
        private int commandIndex = -1;
        public void AddCommand(ICommand command)
        {
            // Přerušení řetězce
            if (commands.Count - 1 != commandIndex && commands.Count - 1 - commandIndex > 0)
            {
                MessageBox.Show($"Počet prvků : {commands.Count - 1} ; \n Počet prvků k odebrání: {commands.Count - 1 - commandIndex} ; \n Index: {commandIndex}");
                commands.RemoveRange(commandIndex + 1, commands.Count - 1 - commandIndex);
            }

            commands.Add(command);
            command.Execute();
            commandIndex++;
        }

        public void Next()
        {
            //CTRL-Y => návrat do aktuálnějšího stavu
            if (commandIndex >= commands.Count - 1)
                return;
            commandIndex++;
            commands[commandIndex].Execute();
        }
        public void Undo()
        {
            //Ctrl-Z => návrat do původního stavu
            if (commandIndex == -1 || commands.Count == 0)
                return;
            commands[commandIndex].Undo();
            commandIndex--;
        }
    }
}

using CommandPattern.Commands.ICommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    internal class CommandQueue
    {
        private List<ICommand> commands = new(4);

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void RemoveCommand(ICommand command)
        {
            commands.Remove(command);
        }

        public void ExecuteCommands()
        {
            commands.ForEach(command => command.Execute());
        }
        
    }
}

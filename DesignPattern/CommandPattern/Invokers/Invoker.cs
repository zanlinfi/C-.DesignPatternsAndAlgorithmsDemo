using CommandPattern.Commands.ICommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Invokers
{
    internal class Invoker(ICommand command)
    {
        private readonly ICommand _command = command;

        public void InvokeCommand()
        {
            _command.Execute();
        }
    }
}

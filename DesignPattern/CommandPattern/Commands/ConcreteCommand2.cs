using CommandPattern.Commands.ICommands;
using CommandPattern.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    internal class ConcreteCommand2(Receiver1 receiver) : ICommand
    {
         private readonly Receiver1 _receiver = receiver;

        public void Execute()
        {
            _receiver.Action2();
        }
    }
}

using CommandPattern.Commands.ICommands;
using CommandPattern.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    internal class ConcreteCommand3(Receiver2 receiver) : ICommand
    {
         private readonly Receiver2 _receiver = receiver;

        public void Execute()
        {
            _receiver.Action1();
        }
        public void Execute2()
        {
            _receiver.Action2();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands.ICommands
{
    internal interface ICommand
    {
        void Execute();
    }
}

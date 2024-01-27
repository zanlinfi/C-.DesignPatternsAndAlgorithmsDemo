using CommandPattern.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Invokers
{
    internal class QueueInvoker(CommandQueue commandQueue)
    {
        private readonly CommandQueue _commandQueue = commandQueue;

        public void ExecuteCommands()
        {
            _commandQueue.ExecuteCommands();
        }
    }
}

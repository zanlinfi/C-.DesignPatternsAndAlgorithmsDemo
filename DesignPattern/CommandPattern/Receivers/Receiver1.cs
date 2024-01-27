using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Receivers
{
    internal class Receiver1
    {
        public void Action1()
        {
            Console.WriteLine("Receiver1 Do Action1");
        }

        public void Action2()
        {
            Console.WriteLine("Receiver1 Do Action2");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObservePattern.Observers.Interfaces;

namespace ObservePattern.Observers
{
    internal class Child : IObserver
    {
        public void Action()
        {
            Console.WriteLine("Child run back home");
        }
    }
}

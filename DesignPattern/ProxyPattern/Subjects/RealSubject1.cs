using ProxyPattern.Subjects.ISubjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Subjects
{
    internal class RealSubject1 : ISubject
    {
        public void DoSomething1()
        {
            Console.WriteLine("Real subject thing1");
        }

        public void DoSomething2()
        {
            Console.WriteLine("Real subject thing2");
        }

        public void DoSomething3()
        {
            Console.WriteLine("Real subject thing3");

        }
    }
}

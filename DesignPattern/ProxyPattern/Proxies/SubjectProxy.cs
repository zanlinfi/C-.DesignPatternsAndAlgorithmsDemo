using ProxyPattern.Subjects;
using ProxyPattern.Subjects.ISubjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Proxies
{
    internal class SubjectProxy(RealSubject1 realSubject1) : ISubject
    {
        private RealSubject1 _realSubject1 = realSubject1;
        public void DoSomething1()
        {
            Console.WriteLine("Proxy do thing1");
            _realSubject1.DoSomething1();
        }

        public void DoSomething2()
        {
            Console.WriteLine("Proxy do thing2");
            _realSubject1.DoSomething2();
        }

        public void DoSomething3()
        {
            Console.WriteLine("Proxy do thing3");
            _realSubject1.DoSomething3();
        }
    }
}

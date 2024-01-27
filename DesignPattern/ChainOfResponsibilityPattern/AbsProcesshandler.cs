using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern
{
    internal abstract class AbsProcesshandler
    {
        public abstract string Staus { get; set; }

        public AbsProcesshandler? Successor { get; set; }

        public void BaseProcess(string status)
        {
            // 可结合模板方法模式
            if (Successor is not null)
            {
                Console.WriteLine($"{status}处理完毕，交由下一级处理"); // 钩子函数替换
                Successor.Process();
                return;
            }
            Console.WriteLine($"{status}完成请求"); // 钩子函数替换
        }

        public abstract void Process();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    internal class ConcreteBusiness1 : TemplateBase
    {
        public override void Step2()
        {
            Console.WriteLine("业务1根据需要重写了步骤二");
        }
    }
}

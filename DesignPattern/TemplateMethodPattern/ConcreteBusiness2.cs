using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    internal class ConcreteBusiness2 : TemplateBase
    {
        public override void Step2()
        {
            Console.WriteLine("业务2根据具体需要重写步骤2");
        }
    }
}

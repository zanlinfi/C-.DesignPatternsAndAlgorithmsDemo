using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern
{
    internal class Manager : AbsProcesshandler
    {

        public override string Staus { get; set; } = "经理";

        public override void Process()
        {
            base.BaseProcess(Staus);
        }
    }
}

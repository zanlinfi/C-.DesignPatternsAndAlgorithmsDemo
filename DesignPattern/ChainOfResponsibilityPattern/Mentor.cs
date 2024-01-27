using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern
{
    internal class Menter: AbsProcesshandler
    {
        
        public override string Staus { get; set; } = "导师";

        public override void Process()
        {
            base.BaseProcess(Staus);
        }
    }
}

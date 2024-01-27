using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern
{
    internal class DomainLeader : AbsProcesshandler
    {
        public override string Staus { get; set; } = "部门领导";
        public override void Process()
        {
            base.BaseProcess(Staus);
        }
    }
}

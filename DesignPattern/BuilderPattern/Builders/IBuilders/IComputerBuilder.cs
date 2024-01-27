using BuilderPattern.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Builders.IBuilders
{
    internal interface IComputerBuilder
    {
        void BuildCpu();
        void BuildGpu();
        void BuildMemory();
        void BuildDisk();
        void BuildScreen();
        void BuildSystem();
        Computer GetComputer();
    }
}

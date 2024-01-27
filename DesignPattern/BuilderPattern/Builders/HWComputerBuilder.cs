using BuilderPattern.Builders.IBuilders;
using BuilderPattern.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Builders
{
    internal class HWComputerBuilder : IComputerBuilder  
    {
        private Computer computer = new();
        public void BuildCpu()
        {
            computer.AddPart("i7 Cpu");
        }

        public void BuildDisk()
        {
            computer.AddPart("changJiang Disk");
        }

        public void BuildGpu()
        {
            computer.AddPart("NVida Gpu");
        }

        public void BuildMemory()
        {
            computer.AddPart("changJiang Memory");
        }

        public void BuildScreen()
        {

            computer.AddPart("JDF Screen");

        }

        public void BuildSystem()
        {
            computer.AddPart("MS System");
        }

        public Computer GetComputer()
        {
            return computer;
        }
    }
}

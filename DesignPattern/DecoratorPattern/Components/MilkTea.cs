using DecoratorPattern.Components.IBaseComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Components
{
    internal class MilkTea : IBaseBeverage
    {
        public double Cost()
        {
            Console.WriteLine("Milk tea needs 10 yuan");
            return 10;
        }
    }
}

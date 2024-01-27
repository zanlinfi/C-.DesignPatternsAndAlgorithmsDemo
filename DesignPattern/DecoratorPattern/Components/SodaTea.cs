using DecoratorPattern.Components.IBaseComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Components
{
    internal class SodaTea : IBaseBeverage
    {
        public double Cost()
        {
            Console.WriteLine("Soda needs 18 yuan");
            return 18;
        }
    }
}

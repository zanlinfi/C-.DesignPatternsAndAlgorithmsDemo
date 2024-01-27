using DecoratorPattern.Components.IBaseComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Components
{
    internal class FruitTea : IBaseBeverage
    {
        public double Cost()
        {
            Console.WriteLine("Fruit tea needs 12 yuan");
            return 12;
        }
    }
}

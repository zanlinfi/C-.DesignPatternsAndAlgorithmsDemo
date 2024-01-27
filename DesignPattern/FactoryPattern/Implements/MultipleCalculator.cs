using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.Interfaces;

namespace FactoryPattern.Implements
{
    internal class MultipleCalculator : ICalculator
    {
        public double Calculate(double x, double y)
        {
            return x * y;
        }
    }
}

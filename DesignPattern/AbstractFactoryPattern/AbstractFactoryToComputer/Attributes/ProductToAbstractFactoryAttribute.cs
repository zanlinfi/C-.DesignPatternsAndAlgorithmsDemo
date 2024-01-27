using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToComputer.Attributes
{
    internal class ProductToAbstractFactoryAttribute(string brand) : Attribute
    {
        public string Brand { get => brand; }

    }
}

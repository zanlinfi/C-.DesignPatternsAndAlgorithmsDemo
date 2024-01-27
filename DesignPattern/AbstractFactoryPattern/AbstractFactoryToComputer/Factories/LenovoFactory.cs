using AbstractFactoryPattern.AbstractFactoryToComputer.Attributes;
using AbstractFactoryPattern.AbstractFactoryToComputer.Implements;
using AbstractFactoryPattern.AbstractFactoryToComputer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToComputer.Factories
{
    [ProductToAbstractFactory("Lenovo")]
    internal class LenovoFactory : IAbstractFactory
    {
        public IKeyboard GetKeyboard()
        {
            return new LenovoKeyboard();
        }

        public IMouse GetMouse()
        {
            return new LenovoMouse();
        }
    }
}

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
    [ProductToAbstractFactory("HP")]
    internal class HPFactory : IAbstractFactory
    {
        public IKeyboard GetKeyboard()
        {
            return new HPKeyboard();
        }

        public IMouse GetMouse()
        {
            return new HPMouse();
        }
    }
}

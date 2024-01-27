using AbstractFactoryPattern.AbstractFactoryToComputer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToComputer.Factories
{
    internal interface IAbstractFactory
    {
        IKeyboard GetKeyboard();
        IMouse GetMouse();
    }
}

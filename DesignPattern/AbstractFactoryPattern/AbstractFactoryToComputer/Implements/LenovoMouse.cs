using AbstractFactoryPattern.AbstractFactoryToComputer.Attributes;
using AbstractFactoryPattern.AbstractFactoryToComputer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToComputer.Implements
{
    internal class LenovoMouse : IMouse
    {
        public void ShowMouseBrand()
        {
            Console.WriteLine("Lenovo鼠标");
        }
    }
}

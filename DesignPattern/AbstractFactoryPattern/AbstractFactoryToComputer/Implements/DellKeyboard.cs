using AbstractFactoryPattern.AbstractFactoryToComputer.Attributes;
using AbstractFactoryPattern.AbstractFactoryToComputer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToComputer.Implements
{
    internal class DellKeyboard : IKeyboard
    {
        public void ShowKeyboardBrand()
        {
            Console.WriteLine("Dell键盘");
        }
    }
}

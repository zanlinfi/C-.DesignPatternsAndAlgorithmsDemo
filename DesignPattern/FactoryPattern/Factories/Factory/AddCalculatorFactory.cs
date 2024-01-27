using FactoryPattern.Implements;
using FactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Factories.Factory
{
    [OperToFactory("+")]
    internal class AddCalculatorFactory : ICalculatorFactory
    {

        /// <summary>
        /// 加法计算器工厂，实现抽象工厂创建加法对象
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ICalculator GetCalculator()
        {
            return new AddCalculator();
        }
    }
}

using FactoryPattern.Implements;
using FactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Factories.SimpleFactory
{
    internal class CalculatorSimpleFactory
    {
        /// <summary>
        /// switch 模式创建对象，简单工厂模式的对象创建都集中再一个方法中，风险会比较高 （抽象依赖细节）
        /// </summary>
        /// <param name="oper"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ICalculator GetCalculator_SimpleFactory(string oper) => oper switch
        {
            "+" => new AddCalculator(),
            "-" => new SubstractCalculator(),
            "/" => new DivideCalculator(),
            "*" => new MultipleCalculator(),
            _ => throw new NotImplementedException()
        };

    }
}

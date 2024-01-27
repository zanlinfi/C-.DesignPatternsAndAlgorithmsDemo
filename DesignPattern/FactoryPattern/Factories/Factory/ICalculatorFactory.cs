using FactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Factories.Factory
{
    /// <summary>
    /// 抽象工厂：实现创建对象的抽象和细节分离（通过接口实现，让具体子类实现接口创建具体对象）
    /// </summary>
    internal interface ICalculatorFactory
    {
        ICalculator GetCalculator();
    }
}

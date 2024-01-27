using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Factories.Factory
{
    internal class ReflectionToFactory
    {
        // 根据用户输入的操作符，拿到对应的工厂对象
        private Dictionary<string, ICalculatorFactory> _operFactoryDic = [];
        public ReflectionToFactory()
        {
            // 1.获取当前正在运行的程序集
            Assembly assembly = Assembly.GetExecutingAssembly();

            // 2.获取具体工厂对象
            foreach (var typeItem in assembly.GetTypes())
            {
                // 3.获取实现了ICalculator接口的类的类型(typeItem 实现了 ICalculatorFactory)（需要排除ICalculatorFactory本身）
                if (typeof(ICalculatorFactory).IsAssignableFrom(typeItem) && !typeItem.IsInterface)
                {
                    // Add、Sub、Div、Mul
                    // 4.拿到对应的Attribute上的数据
                    OperToFactoryAttribute? operToFactoryAttribute = typeItem.GetCustomAttribute<OperToFactoryAttribute>();
                    _ = operToFactoryAttribute ?? throw new NullReferenceException();
                    // 给非空的特属性值赋值
                    if (operToFactoryAttribute.Oper is not null)
                    {
                        // 5.根据操作符创建对应的工厂对象
                        // 5.1给键值对赋值（操作符和对象的映射）
                        _operFactoryDic[operToFactoryAttribute.Oper] = Activator.CreateInstance(typeItem) as ICalculatorFactory ?? throw new NullReferenceException();
                    }
                }
            };
        }

        public ICalculatorFactory GetFactory(string oper)
        {
            if (_operFactoryDic.ContainsKey(oper))
            {
                return _operFactoryDic[oper];
            }
            return null;
        }

    }
}

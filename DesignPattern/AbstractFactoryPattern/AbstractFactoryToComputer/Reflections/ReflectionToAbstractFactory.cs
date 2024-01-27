using AbstractFactoryPattern.AbstractFactoryToComputer.Attributes;
using AbstractFactoryPattern.AbstractFactoryToComputer.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToComputer.Reflections
{
    internal class ReflectionToAbstractFactory
    {
        private Dictionary<string, IAbstractFactory> _abstractFactoryDic = [];

        public ReflectionToAbstractFactory()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (var typeItem in assembly.GetTypes())
            {
                if (typeof(IAbstractFactory).IsAssignableFrom(typeItem) && !typeItem.IsInterface)
                {
                    ProductToAbstractFactoryAttribute? productToAbstractFactoryAttribute = typeItem.GetCustomAttribute<ProductToAbstractFactoryAttribute>();
                    _ = productToAbstractFactoryAttribute ?? throw new NullReferenceException();
                    if (productToAbstractFactoryAttribute.Brand is not null)
                    {
                        _abstractFactoryDic[productToAbstractFactoryAttribute.Brand] = Activator.CreateInstance(typeItem) as IAbstractFactory ?? throw new NullReferenceException();
                    }
                }
            }
        }
        public IAbstractFactory GetFactory(string brand)
        {
            if (_abstractFactoryDic.ContainsKey(brand))
            {
                return _abstractFactoryDic[brand];
            }
            return null;
        }
    }
}

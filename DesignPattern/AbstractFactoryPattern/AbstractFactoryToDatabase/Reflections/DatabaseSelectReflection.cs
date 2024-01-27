using AbstractFactoryPattern.AbstractFactoryToComputer.Attributes;
using AbstractFactoryPattern.AbstractFactoryToComputer.Factories;
using AbstractFactoryPattern.AbstractFactoryToDatabase.Attributes;
using AbstractFactoryPattern.AbstractFactoryToDatabase.Factories.IFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToDatabase.Reflections
{
    internal class DatabaseSelectReflection
    {
        private Dictionary<string, IDatabaseFactory> _abstractFactoryDic = [];

        public DatabaseSelectReflection()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (var typeItem in assembly.GetTypes())
            {
                if (typeof(IDatabaseFactory).IsAssignableFrom(typeItem) && !typeItem.IsInterface)
                {
                    DatabaseOptionAttribute? databaseOption = typeItem.GetCustomAttribute<DatabaseOptionAttribute>();
                    _ = databaseOption ?? throw new NullReferenceException();
                    if (databaseOption.DatabaseType is not null)
                    {
                        _abstractFactoryDic[databaseOption.DatabaseType] = Activator.CreateInstance(typeItem) as IDatabaseFactory ?? throw new NullReferenceException();
                    }
                }
            }
        }
        public IDatabaseFactory GetFactory(string brand)
        {
            if (_abstractFactoryDic.ContainsKey(brand))
            {
                return _abstractFactoryDic[brand];
            }
            return null;
        }
    }
}

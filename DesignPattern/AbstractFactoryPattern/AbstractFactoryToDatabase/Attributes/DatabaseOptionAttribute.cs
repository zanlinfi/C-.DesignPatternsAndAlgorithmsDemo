using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToDatabase.Attributes
{
    internal class DatabaseOptionAttribute(string databaseType) : Attribute
    {
        public string DatabaseType { get => databaseType; }
    }
}

using AbstractFactoryPattern.AbstractFactoryToDatabase.Databases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToDatabase.Factories.IFactories
{
    internal interface IDatabaseFactory
    {
        IDatabaseUser GetDatabaseUser();
        IDatabaseDepartment GetDatabaseDepartment();
    }
}

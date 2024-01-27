using AbstractFactoryPattern.AbstractFactoryToDatabase.Attributes;
using AbstractFactoryPattern.AbstractFactoryToDatabase.Databases.Interfaces;
using AbstractFactoryPattern.AbstractFactoryToDatabase.DataBases;
using AbstractFactoryPattern.AbstractFactoryToDatabase.Factories.IFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToDatabase.Factories
{
    [DatabaseOption("Sqlserver")]
    internal class SqlserverFactory : IDatabaseFactory
    {
        public IDatabaseDepartment GetDatabaseDepartment()
        {
            return new DepartmentSqlserver();
        }

        public IDatabaseUser GetDatabaseUser()
        {
            return new UserSqlserver();
        }
    }
}

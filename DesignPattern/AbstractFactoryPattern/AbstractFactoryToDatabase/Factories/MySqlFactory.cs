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
    [DatabaseOption("MySql")]
    internal class MySqlFactory : IDatabaseFactory
    {
        public IDatabaseDepartment GetDatabaseDepartment()
        {
            return new DepartmentMySql();
        }

        public IDatabaseUser GetDatabaseUser()
        {
            return new UserMySql();
        }
    }
}

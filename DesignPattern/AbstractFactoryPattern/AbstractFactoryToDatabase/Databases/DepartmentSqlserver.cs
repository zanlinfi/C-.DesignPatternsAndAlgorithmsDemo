using AbstractFactoryPattern.AbstractFactoryToDatabase.Databases.Interfaces;
using AbstractFactoryPattern.AbstractFactoryToDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToDatabase.DataBases
{
    internal class DepartmentSqlserver : IDatabaseDepartment
    {
        public Department GetDepartment(int id)
        {
            Console.WriteLine("Sqlserver get department");
            return new Department { ID = id, Name = "departName" };
        }

        public int InsertDepartment(Department user)
        {
            Console.WriteLine("Sqlserver insert department");
            return 1;
        }
    }
}

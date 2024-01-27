using AbstractFactoryPattern.AbstractFactoryToDatabase.Databases.Interfaces;
using AbstractFactoryPattern.AbstractFactoryToDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToDatabase.DataBases
{
    internal class DepartmentSqlLite : IDatabaseDepartment
    {
        public Department GetDepartment(int id)
        {
            Console.WriteLine("SqlLite get department");
            return new Department { ID = id, Name = "departName" };
        }

        public int InsertDepartment(Department user)
        {
            Console.WriteLine("SqlLite insert department");
            return 1;
        }
    }
}

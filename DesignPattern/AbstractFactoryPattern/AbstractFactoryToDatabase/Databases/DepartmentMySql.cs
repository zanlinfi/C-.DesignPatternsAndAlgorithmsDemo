using AbstractFactoryPattern.AbstractFactoryToDatabase.Databases.Interfaces;
using AbstractFactoryPattern.AbstractFactoryToDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToDatabase.DataBases
{
    internal class DepartmentMySql : IDatabaseDepartment
    {
        public Department GetDepartment(int id)
        {
            Console.WriteLine("Mysql get department");
            return new Department { ID = id, Name = "departName" };
        }

        public int InsertDepartment(Department user)
        {
            Console.WriteLine("Mysql insert department");
            return 1;
        }
    }
}

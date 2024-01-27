using AbstractFactoryPattern.AbstractFactoryToDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToDatabase.Databases.Interfaces
{
    internal interface IDatabaseDepartment
    {
        int InsertDepartment(Department user);
        Department GetDepartment(int id);
    }
}

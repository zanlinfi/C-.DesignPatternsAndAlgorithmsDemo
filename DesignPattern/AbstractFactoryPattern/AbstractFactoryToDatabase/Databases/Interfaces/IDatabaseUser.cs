using AbstractFactoryPattern.AbstractFactoryToDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToDatabase.Databases.Interfaces
{
    internal interface IDatabaseUser
    {
        int InsertUser(User user);
        User GetUser(int id);
    }
}

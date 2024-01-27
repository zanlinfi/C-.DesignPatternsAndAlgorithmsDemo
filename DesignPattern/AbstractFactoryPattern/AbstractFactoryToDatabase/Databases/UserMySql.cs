using AbstractFactoryPattern.AbstractFactoryToDatabase.Databases.Interfaces;
using AbstractFactoryPattern.AbstractFactoryToDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToDatabase.DataBases
{
    internal class UserMySql : IDatabaseUser
    {
        public User GetUser(int id)
        {
            Console.WriteLine("MySql get Username");
            return new User { ID = id, Name = "username" };
        }

        public int InsertUser(User user)
        {
            Console.WriteLine("MySql insert a user");
            return 1;
        }
    }
}

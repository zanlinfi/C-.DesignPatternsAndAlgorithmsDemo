using AbstractFactoryPattern.AbstractFactoryToDatabase.Databases.Interfaces;
using AbstractFactoryPattern.AbstractFactoryToDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactoryToDatabase.DataBases
{
    internal class UserSqlserver : IDatabaseUser
    {
        public User GetUser(int id)
        {
            Console.WriteLine("Sqlserver Get Username");
            return new User { ID = id, Name = "username"};
        }

        public int InsertUser(User user)
        {
            Console.WriteLine("Sqlserver Insert a user");
            return 1;
        }
    }
}

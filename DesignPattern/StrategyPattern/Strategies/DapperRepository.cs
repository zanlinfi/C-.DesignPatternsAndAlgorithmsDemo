using StrategyPattern.Strategies.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies
{
    internal class DapperRepository : IRepository
    {
        public void Algorithm()
        {
            Console.WriteLine("Dapper repository");
        }
    }
}

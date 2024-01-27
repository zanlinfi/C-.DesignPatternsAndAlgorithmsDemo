using StrategyPattern.Strategies.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies
{
    internal class EFCoreRepository : IRepository
    {
        public void Algorithm()
        {
            Console.WriteLine("EF Core repository");
        }
    }
}

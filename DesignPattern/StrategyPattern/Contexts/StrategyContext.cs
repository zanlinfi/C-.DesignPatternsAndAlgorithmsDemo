using StrategyPattern.Strategies;
using StrategyPattern.Strategies.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Contexts
{
    internal class StrategyContext(IRepository repository)
    {
        //public IRepository Repository { get; set; } = repository;
        public void Algorithm()
        {
            repository.Algorithm();
        }
    }
}

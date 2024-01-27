using StatePattern.Contexts;
using StatePattern.StateEnums;
using StatePattern.States.IStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    internal class WaterGas : IWaterState
    {
        public WaterStateEnum State { get; set; } = WaterStateEnum.Gas;

        public void Action()
        {
            Console.WriteLine("Gas water do something");
        }
        
    }
}

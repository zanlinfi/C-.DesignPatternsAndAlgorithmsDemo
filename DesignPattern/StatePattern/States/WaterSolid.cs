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
    internal class WaterSolid : IWaterState
    {
        public WaterStateEnum State { get; set ; } = WaterStateEnum.Solid;

        public void Action()
        {
            Console.WriteLine("Solid water do something");
        }
    }
}

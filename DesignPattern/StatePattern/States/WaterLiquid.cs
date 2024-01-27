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
    internal class WaterLiquid : IWaterState
    {
        public WaterStateEnum State { get; set; } = WaterStateEnum.Liquid;

        public void Action()
        {
            Console.WriteLine("Liquid water do something");
        }
    }
}

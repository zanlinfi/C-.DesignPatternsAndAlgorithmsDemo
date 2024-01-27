using StatePattern.StateEnums;
using StatePattern.States;
using StatePattern.States.IStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Contexts
{
    internal class WaterStateContext
    {
        public IWaterState CurrentWaterSate { get; set; }

        public void Action()
        {
            CurrentWaterSate.Action();
        }

        public void SetState(IWaterState state)
        {
            CurrentWaterSate = state;
        }

        public void SetState2(WaterStateEnum state)
        {
            CurrentWaterSate = StateSwitch(state);
        }

        private IWaterState StateSwitch(WaterStateEnum state) => state switch
        {
            WaterStateEnum.Gas => new WaterGas(),
            WaterStateEnum.Solid => new WaterSolid(),
            WaterStateEnum.Liquid => new WaterLiquid(),
            WaterStateEnum.None => new WaterGas(),
            _ => throw new NotImplementedException()
        };
    }
}

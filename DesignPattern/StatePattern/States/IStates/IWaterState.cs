using StatePattern.Contexts;
using StatePattern.StateEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States.IStates
{
    internal interface IWaterState
    {
        WaterStateEnum State { get; set; }

        void Action();

        //void ChangeState(WaterStateContext state);
    }
}

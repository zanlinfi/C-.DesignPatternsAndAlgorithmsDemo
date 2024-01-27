using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Targets
{
    /// <summary>
    /// 目标对象接口，要实现IPhone手机充电
    /// </summary>
    internal interface IIPhoneChargingPort
    {
        void IPhoneCharge();
    }
}

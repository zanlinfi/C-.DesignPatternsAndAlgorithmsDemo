using AdapterPattern.Adaptee;
using AdapterPattern.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Adapters
{
    /// <summary>
    /// 作为转接口，在Adapter类中去实现目标对象接口，重写目标对象方法，调用Adaptee中的方法，使得TypeC的接口可以同时适配器给IPhone的接口充电
    /// </summary>
    internal class ChargeAdapter : IIPhoneChargingPort
    {
        //在Adapter中封装了Adaptee对象，通过这个对象实现功能的转接[core]
        private TypeCChargingCable androidCharger = new();
        public void IPhoneCharge()
        {
            Console.WriteLine("Adapter adaptes iPhone port with android charging line");
            androidCharger.AndroidCharge();  // 真正干活儿的
            Console.WriteLine("Implement iPone charge");
        }
    }
}

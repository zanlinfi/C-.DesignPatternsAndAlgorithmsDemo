using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Adaptee
{
    /// <summary>
    /// 具有实际的功能，可以给Android手机充电，但是不能直接给苹果手机充电
    /// </summary>
    internal class TypeCChargingCable
    {
        public void AndroidCharge()
        {
            Console.WriteLine("Android charging line charge");
        }
    }
}

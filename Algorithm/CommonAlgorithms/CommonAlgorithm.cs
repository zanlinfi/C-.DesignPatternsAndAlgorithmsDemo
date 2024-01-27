using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonAlgorithm
{
    internal static class CommonAlgorithm
    {
        /// <summary>
        /// 判断是否为质数（传统方法）
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static Boolean IsPrime(int num)
        {
            if (num <= 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

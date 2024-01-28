using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonAlgorithm
{
    internal static class CommonAlgorithms
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

        /// <summary>
        /// 二分查找算法（双闭区间）
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int BinarySearch(int[] nums, int target)
        {
            // 初始化双闭区间 [0, n-1] ，即 i, j 分别指向数组首元素、尾元素
            int i = 0, j = nums.Length - 1;
            // 循环，当搜索区间为空时跳出（当 i > j 时为空）
            while (i <= j)
            {
                // 计算中点索引 m
                int m = i + (j - i) / 2;   
                // 此情况说明 target 在区间 [m+1, j] 中
                if (nums[m] < target)      
                {
                    i = m + 1;
                }
                // 此情况说明 target 在区间 [i, m-1] 中
                else if (nums[m] > target)
                {
                    j = m - 1;
                }
                // 找到目标元素，返回其索引
                else
                {
                    return m;
                }
            }
            // 未找到目标元素，返回 -1
            return -1;
        }

    }
}

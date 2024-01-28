using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCase
{
    internal static class AlgorithmCases
    {
        /*
         * 1.给定一个长度为n的有序数组 nums 和一个元素 target ，数组不存在重复元素。现将 target 插入数组 nums 中，并保持其有序性。
         * 若数组中已存在元素 target ，则插入到其左方。请返回插入后 target 在数组中的索引。
        */
        #region 1
        /* 二分查找插入点（无重复元素） */
        public static int BinarySearchInsertionSimple(int[] nums, int target)
        {
            int i = 0, j = nums.Length - 1; // 初始化双闭区间 [0, n-1]
            while (i <= j)
            {
                int m = i + (j - i) / 2; // 计算中点索引 m
                if (nums[m] < target)
                {
                    i = m + 1; // target 在区间 [m+1, j] 中
                }
                else if (nums[m] > target)
                {
                    j = m - 1; // target 在区间 [i, m-1] 中
                }
                else
                {
                    return m; // 找到 target ，返回插入点 m
                }
            }
            // 未找到 target ，返回插入点 i
            return i;
        }

        /* 二分查找插入点（存在重复元素） */
        public static int BinarySearchInsertion(int[] nums, int target)
        {
            int i = 0, j = nums.Length - 1; // 初始化双闭区间 [0, n-1]
            while (i <= j)
            {
                int m = i + (j - i) / 2; // 计算中点索引 m
                if (nums[m] < target)
                {
                    i = m + 1; // target 在区间 [m+1, j] 中
                }
                else if (nums[m] > target)
                {
                    j = m - 1; // target 在区间 [i, m-1] 中
                }
                else
                {
                    j = m - 1; // 首个小于 target 的元素在区间 [i, m-1] 中
                }
            }
            // 返回插入点 i
            return i;
        }
        #endregion

        /*
         * 2.给定一个整数数组 nums 和一个目标元素 target ，请在数组中搜索“和”为 target 的两个元素，并返回它们的数组索引。
         * 返回任意一个解即可。
         */
        #region 2
        /* 方法一：暴力枚举 */
        public static int[] TwoSumBruteForce(int[] nums, int target)
        {
            int size = nums.Length;
            // 两层循环，时间复杂度为 O(n^2)
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (nums[i] + nums[j] == target)
                        return [i, j];
                }
            }
            return [];
        }

        /* 方法二：辅助哈希表 */
        public static int[] TwoSumHashTable(int[] nums, int target)
        {
            int size = nums.Length;
            // 辅助哈希表，空间复杂度为 O(n)
            Dictionary<int, int> dic = [];
            // 单层循环，时间复杂度为 O(n)
            for (int i = 0; i < size; i++)
            {
                // 只要target-nums[i]在Hash表中，则为一组解，返回其索引即可[core]
                if (dic.ContainsKey(target - nums[i]))
                {
                    return [dic[target - nums[i]], i];
                }
                // 值为Key，索引为Value
                dic.Add(nums[i], i);
            }
            return [];
        }
        #endregion

    }
}

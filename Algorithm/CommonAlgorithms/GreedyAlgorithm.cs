using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonAlgorithm
{
    /// <summary>
    /// 贪心算法：是一种常见的解决优化问题的算法，其基本思想是在问题的每个决策阶段，都选择当前看起来最优的选择，
    /// 即贪心地做出局部最优的决策，以期获得全局最优解。
    /// 贪心算法和动态规划都常用于解决优化问题。它们之间存在一些相似之处，比如都依赖最优子结构性质，但工作原理不同。
    /// 动态规划会根据之前阶段的所有决策来考虑当前决策，并使用过去子问题的解来构建当前子问题的解。
    /// 贪心算法不会考虑过去的决策，而是一路向前地进行贪心选择，不断缩小问题范围，直至问题被解决。
    /// 贪心算法不仅操作直接、实现简单，而且通常效率也很高，但是并不总是能找到最优解
    /// </summary>
    internal static class GreedyAlgorithm
    {
        #region 零钱兑换问题
        /// <summary>
        /// 零钱兑换：贪心 
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amt"></param>
        /// <returns></returns>
        static int CoinChangeGreedy(int[] coins, int amt)
        {
            // 假设 coins 列表有序
            int i = coins.Length - 1;
            int count = 0;
            // 循环进行贪心选择，直到无剩余金额
            while (amt > 0)
            {
                // 找到小于且最接近剩余金额的硬币
                while (i > 0 && coins[i] > amt)
                {
                    i--;
                }
                // 选择 coins[i]
                amt -= coins[i];
                count++;
            }
            // 若未找到可行方案，则返回 -1
            return amt == 0 ? count : -1;
        }
        #endregion

        #region 分数背包问题
        /*
         *给定n个物品，第个物品的重量为wgt[i－1]、价值为ual[i－1]，和一个容量为cap的背包。
         *每个物品只能选择一次，但可以选择物品的一部分，价值根据选择的重量比例计算，问在限定背包容量下背包中物品的最大价值。
         */
        /* 物品 */
        class Item(int w, int v)
        {
            public int w = w; // 物品重量
            public int v = v; // 物品价值
        }

        /// <summary>
        /// 分数背包：贪心
        /// </summary>
        /// <param name="wgt"></param>
        /// <param name="val"></param>
        /// <param name="cap"></param>
        /// <returns></returns>
        static double FractionalKnapsack(int[] wgt, int[] val, int cap)
        {
            // 创建物品列表，包含两个属性：重量、价值
            Item[] items = new Item[wgt.Length];
            for (int i = 0; i < wgt.Length; i++)
            {
                items[i] = new Item(wgt[i], val[i]);
            }
            // 按照单位价值 item.v / item.w 从高到低进行排序
            Array.Sort(items, (x, y) => (y.v / y.w).CompareTo(x.v / x.w));
            // 循环贪心选择
            double res = 0;
            foreach (Item item in items)
            {
                if (item.w <= cap)
                {
                    // 若剩余容量充足，则将当前物品整个装进背包
                    res += item.v;
                    cap -= item.w;
                }
                else
                {
                    // 若剩余容量不足，则将当前物品的一部分装进背包
                    res += (double)item.v / item.w * cap;
                    // 已无剩余容量，因此跳出循环
                    break;
                }
            }
            return res;
        }
        #endregion

        #region 最大容量问题
        /*
         * 输入一个数组ht，其中的每个元素代表一个垂直隔板的高度。数组中的任意两个隔板，以及它们之间的空间可以组成一个容器。
         * 容器的容量等于高度和宽度的乘积（面积），其中高度由较短的隔板决定，宽度是两个隔板的数组索引之差。
         * 请在数组中选择两个隔板，使得组成的容器的容量最大，返回最大容量
         */
        /* 最大容量：贪心 */
        static int MaxCapacity(int[] ht)
        {
            // 初始化 i, j，使其分列数组两端
            int i = 0, j = ht.Length - 1;
            // 初始最大容量为 0
            int res = 0;
            // 循环贪心选择，直至两板相遇
            while (i < j)
            {
                // 更新最大容量
                int cap = Math.Min(ht[i], ht[j]) * (j - i);
                res = Math.Max(res, cap);
                // 向内移动短板
                if (ht[i] < ht[j])
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
            return res;
        }
        #endregion

        #region 最大切分乘积问题
        /*
         * 给定一个正整数n，将其切分为至少两个正整数的和，求切分后所有整数的乘积最大是多。
         */
        /* 最大切分乘积：贪心 */
        static int MaxProductCutting(int n)
        {
            // 当 n <= 3 时，必须切分出一个 1
            if (n <= 3)
            {
                return 1 * (n - 1);
            }
            // 贪心地切分出 3 ，a 为 3 的个数，b 为余数
            int a = n / 3;
            int b = n % 3;
            if (b == 1)
            {
                // 当余数为 1 时，将一对 1 * 3 转化为 2 * 2
                return (int)Math.Pow(3, a - 1) * 2 * 2;
            }
            if (b == 2)
            {
                // 当余数为 2 时，不做处理
                return (int)Math.Pow(3, a) * 2;
            }
            // 当余数为 0 时，不做处理
            return (int)Math.Pow(3, a);
        }
        #endregion
    }
}

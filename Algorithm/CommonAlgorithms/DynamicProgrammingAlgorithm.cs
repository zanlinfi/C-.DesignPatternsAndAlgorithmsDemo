using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonAlgorithm
{
    /// <summary>
    /// 动态规划：是一个重要的算法范式，它将一个问题分解为一系列更小的子问题，并通过存储子问题的解来避免重复计算，
    /// 从而大幅提升时间效率。动态归还一般不包含回溯过程，所以只需使用循环迭代。
    /// 动态规划与分治算法的主要区别是，动态规划中的子问题是相互依赖的，在分解过程中会出现许多重叠子问题。
    /// 动态规划常用于寻找最优解决策略，而不是所有解决方案，一般具有决策过程（选或不选）的问题都可以采用DP
    /// </summary>
    internal static class DynamicProgrammingAlgorithm
    {
        #region 爬楼梯问题
        /*
         * 给定一个共有n阶的楼梯，你每步可以上1阶或者2阶，请问有多少种方案可以爬到楼顶？
         */
        /// <summary>
        /// 爬楼梯：动态规划
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int ClimbingStairsDP(int n)
        {
            if (n == 1 || n == 2)
                return n;
            // 初始化 dp 表，用于存储子问题的解
            int[] dp = new int[n + 1];
            // 初始状态：预设最小子问题的解
            dp[1] = 1;
            dp[2] = 2;
            // 状态转移：从较小子问题逐步求解较大子问题
            for (int i = 3; i <= n; i++)
            {
                // 类似递推
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        /// <summary>
        /// 爬楼梯：空间优化后的动态规划
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int ClimbingStairsDPCompII(int n)
        {
            if (n == 1 || n == 2)
                return n;
            int a = 1, b = 2;
            for (int i = 3; i <= n; i++)
            {
                // 使用一个临时变量更新求得的解，即：dp[i] = dp[i - 1] + dp[i - 2];
                int tmp = b;
                b = a + b;
                a = tmp;
            }
            return b;
        }
        #endregion

        #region 0-1背包问题
        /*
        *   给定n个物品，第个物品的重量为[wgt－1]、价值为[val－1]，和一个容量为cap的背包。
        *   每个物品只能选择一次，问在限定背包容量下能放入物品的最大价值。
        */
        /// <summary>
        /// 0-1 背包：动态规划 
        /// </summary>
        /// <param name="weight"></param>
        /// <param name="val"></param>
        /// <param name="cap"></param>
        /// <returns></returns>
        public static int KnapsackDP(int[] weight, int[] val, int cap)
        {
            int n = weight.Length;
            // 初始化 dp 表
            int[,] dp = new int[n + 1, cap + 1];
            // 状态转移
            for (int i = 1; i <= n; i++)
            {
                for (int c = 1; c <= cap; c++)
                {
                    if (weight[i - 1] > c)
                    {
                        // 若超过背包容量，则不选物品 i
                        dp[i, c] = dp[i - 1, c];
                    }
                    else
                    {
                        // 不选和选物品 i 这两种方案的较大值
                        dp[i, c] = Math.Max(dp[i - 1, c - weight[i - 1]] + val[i - 1], dp[i - 1, c]);
                    }
                }
            }
            return dp[n, cap];
        }

        /// <summary>
        /// 0-1 背包：空间优化后的动态规划
        /// </summary>
        /// <param name="weight"></param>
        /// <param name="val"></param>
        /// <param name="cap"></param>
        /// <returns></returns>
        public static int KnapsackDPComp(int[] weight, int[] val, int cap)
        {
            int n = weight.Length;
            // 初始化 dp 表
            int[] dp = new int[cap + 1];
            // 状态转移
            for (int i = 1; i <= n; i++)
            {
                // 倒序遍历
                for (int c = cap; c > 0; c--)
                {
                    if (weight[i - 1] > c)
                    {
                        // 若超过背包容量，则不选物品 i
                        dp[c] = dp[c];
                    }
                    else
                    {
                        // 不选和选物品 i 这两种方案的较大值
                        dp[c] = Math.Max(dp[c], dp[c - weight[i - 1]] + val[i - 1]);
                    }
                }
            }
            return dp[cap];
        }
        #endregion

        #region 完全背包问题
        /*
         *给定n个物品，第个物品的重量为wgt[i－1]、价值为ual[i－1]，和一个容量为cap的背包。每个物品可以重复选取，
         *问在限定背包容量下能放入物品的最大价值
         */
        /// <summary>
        /// 完全背包：动态规划
        /// </summary>
        /// <param name="wgt"></param>
        /// <param name="val"></param>
        /// <param name="cap"></param>
        /// <returns></returns>
        public static int UnboundedKnapsackDP(int[] wgt, int[] val, int cap)
        {
            int n = wgt.Length;
            // 初始化 dp 表
            int[,] dp = new int[n + 1, cap + 1];
            // 状态转移
            for (int i = 1; i <= n; i++)
            {
                for (int c = 1; c <= cap; c++)
                {
                    if (wgt[i - 1] > c)
                    {
                        // 若超过背包容量，则不选物品 i
                        dp[i, c] = dp[i - 1, c];
                    }
                    else
                    {
                        // 不选和选物品 i 这两种方案的较大值
                        dp[i, c] = Math.Max(dp[i - 1, c], dp[i, c - wgt[i - 1]] + val[i - 1]);
                    }
                }
            }
            return dp[n, cap];
        }

        /// <summary>
        /// 完全背包：空间优化后的动态规划
        /// </summary>
        /// <param name="wgt"></param>
        /// <param name="val"></param>
        /// <param name="cap"></param>
        /// <returns></returns>
        public static int UnboundedKnapsackDPComp(int[] wgt, int[] val, int cap)
        {
            int n = wgt.Length;
            // 初始化 dp 表
            int[] dp = new int[cap + 1];
            // 状态转移
            for (int i = 1; i <= n; i++)
            {
                for (int c = 1; c <= cap; c++)
                {
                    if (wgt[i - 1] > c)
                    {
                        // 若超过背包容量，则不选物品 i
                        dp[c] = dp[c];
                    }
                    else
                    {
                        // 不选和选物品 i 这两种方案的较大值
                        dp[c] = Math.Max(dp[c], dp[c - wgt[i - 1]] + val[i - 1]);
                    }
                }
            }
            return dp[cap];
        }
        #endregion

        #region 零钱兑换问题
        /*
         *给定n种硬币，第i种硬币的面值为coins[i－1]，目标金额为αmt，每种硬币可以重复选取，
         *问能够凑出目标金额的最少硬币数量。如果无法凑出目标金额，则返回一1。 （完全背包的特殊情况）
         */
        /// <summary>
        /// 零钱兑换：动态规划 
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amt"></param>
        /// <returns></returns>
        static int CoinChangeDP(int[] coins, int amt)
        {
            int n = coins.Length;
            int MAX = amt + 1;
            // 初始化 dp 表
            int[,] dp = new int[n + 1, amt + 1];
            // 状态转移：首行首列
            for (int a = 1; a <= amt; a++)
            {
                dp[0, a] = MAX;
            }
            // 状态转移：其余行和列
            for (int i = 1; i <= n; i++)
            {
                for (int a = 1; a <= amt; a++)
                {
                    if (coins[i - 1] > a)
                    {
                        // 若超过目标金额，则不选硬币 i
                        dp[i, a] = dp[i - 1, a];
                    }
                    else
                    {
                        // 不选和选硬币 i 这两种方案的较小值
                        dp[i, a] = Math.Min(dp[i - 1, a], dp[i, a - coins[i - 1]] + 1);
                    }
                }
            }
            return dp[n, amt] != MAX ? dp[n, amt] : -1;
        }

        /// <summary>
        /// 零钱兑换：空间优化后的动态规划
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amt"></param>
        /// <returns></returns>
        static int CoinChangeDPComp(int[] coins, int amt)
        {
            int n = coins.Length;
            int MAX = amt + 1;
            // 初始化 dp 表
            int[] dp = new int[amt + 1];
            Array.Fill(dp, MAX);
            dp[0] = 0;
            // 状态转移
            for (int i = 1; i <= n; i++)
            {
                for (int a = 1; a <= amt; a++)
                {
                    if (coins[i - 1] > a)
                    {
                        // 若超过目标金额，则不选硬币 i
                        dp[a] = dp[a];
                    }
                    else
                    {
                        // 不选和选硬币 i 这两种方案的较小值
                        dp[a] = Math.Min(dp[a], dp[a - coins[i - 1]] + 1);
                    }
                }
            }
            return dp[amt] != MAX ? dp[amt] : -1;
        }
        #endregion

        #region 零钱兑换问题II
        /*
         * 给定n种硬币，第i种硬币的面值为coins[i－1]，目标金额为amt，每种硬币可以重复选取，问凑出目标金额的硬币组合数量
         */
        /// <summary>
        /// 零钱兑换 II：动态规划
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amt"></param>
        /// <returns></returns>
        static int CoinChangeIIDP(int[] coins, int amt)
        {
            int n = coins.Length;
            // 初始化 dp 表
            int[,] dp = new int[n + 1, amt + 1];
            // 初始化首列
            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = 1;
            }
            // 状态转移
            for (int i = 1; i <= n; i++)
            {
                for (int a = 1; a <= amt; a++)
                {
                    if (coins[i - 1] > a)
                    {
                        // 若超过目标金额，则不选硬币 i
                        dp[i, a] = dp[i - 1, a];
                    }
                    else
                    {
                        // 不选和选硬币 i 这两种方案之和
                        dp[i, a] = dp[i - 1, a] + dp[i, a - coins[i - 1]];
                    }
                }
            }
            return dp[n, amt];
        }

        /// <summary>
        /// 零钱兑换 II：空间优化后的动态规划
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amt"></param>
        /// <returns></returns>
        static int CoinChangeIIDPComp(int[] coins, int amt)
        {
            int n = coins.Length;
            // 初始化 dp 表
            int[] dp = new int[amt + 1];
            dp[0] = 1;
            // 状态转移
            for (int i = 1; i <= n; i++)
            {
                for (int a = 1; a <= amt; a++)
                {
                    if (coins[i - 1] > a)
                    {
                        // 若超过目标金额，则不选硬币 i
                        dp[a] = dp[a];
                    }
                    else
                    {
                        // 不选和选硬币 i 这两种方案之和
                        dp[a] = dp[a] + dp[a - coins[i - 1]];
                    }
                }
            }
            return dp[amt];
        }
        #endregion

        #region 字符串编辑问题
        /*
         * 输入两个字符串s和t，返回将s转换为t所需的最少编辑步数。你可以在一个字符串中进行三种编辑操作：
         * 插入一个字符、删除一个字符、将字符替换为任意一个字符。
         */
        /// <summary>
        ///  编辑距离：动态规划 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        static int EditDistanceDP(string s, string t)
        {
            int n = s.Length, m = t.Length;
            int[,] dp = new int[n + 1, m + 1];
            // 状态转移：首行首列
            for (int i = 1; i <= n; i++)
            {
                dp[i, 0] = i;
            }
            for (int j = 1; j <= m; j++)
            {
                dp[0, j] = j;
            }
            // 状态转移：其余行和列
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        // 若两字符相等，则直接跳过此两字符
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        // 最少编辑步数 = 插入、删除、替换这三种操作的最少编辑步数 + 1
                        dp[i, j] = Math.Min(Math.Min(dp[i, j - 1], dp[i - 1, j]), dp[i - 1, j - 1]) + 1;
                    }
                }
            }
            return dp[n, m];
        }

        /// <summary>
        /// 编辑距离：空间优化后的动态规划
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        static int EditDistanceDPComp(string s, string t)
        {
            int n = s.Length, m = t.Length;
            int[] dp = new int[m + 1];
            // 状态转移：首行
            for (int j = 1; j <= m; j++)
            {
                dp[j] = j;
            }
            // 状态转移：其余行
            for (int i = 1; i <= n; i++)
            {
                // 状态转移：首列
                int leftup = dp[0]; // 暂存 dp[i-1, j-1]
                dp[0] = i;
                // 状态转移：其余列
                for (int j = 1; j <= m; j++)
                {
                    int temp = dp[j];
                    if (s[i - 1] == t[j - 1])
                    {
                        // 若两字符相等，则直接跳过此两字符
                        dp[j] = leftup;
                    }
                    else
                    {
                        // 最少编辑步数 = 插入、删除、替换这三种操作的最少编辑步数 + 1
                        dp[j] = Math.Min(Math.Min(dp[j - 1], dp[j]), leftup) + 1;
                    }
                    leftup = temp; // 更新为下一轮的 dp[i-1, j-1]
                }
            }
            return dp[m];
        }
        #endregion
    }
}

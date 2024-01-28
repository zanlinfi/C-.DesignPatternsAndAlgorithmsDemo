using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonAlgorithm
{
    /// <summary>
    /// 分治算法：用于将复杂问题进行拆分处理，达到分而治之的效果，也可以提高算法效率，主要分为分和治两个部分，常用递归实现。
    /// 分（划分问题）：递归地将原问题分解为两个或多个子问题，直至到达最小子问题时终止。
    /// 治（合并结果）：从已知解的最小子问题开始，从底至顶地将子问题的解进行合并，从而构建出原问题的解。
    /// 满足条件：1.问题可以分解；2.分解后的各个子问题相互独立没有依赖；3.子问题的解可以合并
    /// </summary>
    internal class DivideConquerAlgorithm
    {
        /*
         * 分治思想在解决算法问题中的应用
         */

        #region 汉诺塔问题
        /*
         * 给定三根柱子，记为 A、B 和 C 。起始状态下，柱子 A 上套着个圆盘，它们从上到下按照从小到大的顺序排列。
         * 我们的任务是要把这个圆盘移到柱子 C 上，并保持它们的原有顺序不变，需遵守以下规则。
         * 1.圆盘只能从一根柱子顶部拿出，从另一根柱子顶部放入。
         * 2.每次只能移动一个圆盘。
         * 3.小圆盘必须时刻位于大圆盘之上。
         */

        /* 求解汉诺塔问题 */
        void SolveHanota(List<int> A, List<int> B, List<int> C)
        {
            int n = A.Count;
            // 将 A 顶部 n 个圆盘借助 B 移到 C
            DFS(n, A, B, C);
        }

        /* 求解汉诺塔问题 f(i) */
        void DFS(int i, List<int> src, List<int> buf, List<int> tar)
        {
            // 若 src 只剩下一个圆盘，则直接将其移到 tar
            if (i == 1)
            {
                Move(src, tar);
                return;
            }
            // 子问题 f(i-1) ：将 src 顶部 i-1 个圆盘借助 tar 移到 buf
            DFS(i - 1, src, tar, buf);
            // 子问题 f(1) ：将 src 剩余一个圆盘移到 tar
            Move(src, tar);
            // 子问题 f(i-1) ：将 buf 顶部 i-1 个圆盘借助 src 移到 tar
            DFS(i - 1, buf, src, tar);
        }

        /* 移动一个圆盘 */
        void Move(List<int> src, List<int> tar)
        {
            // 从 src 顶部拿出一个圆盘
            int pan = src[^1];
            src.RemoveAt(src.Count - 1);
            // 将圆盘放入 tar 顶部
            tar.Add(pan);
        }
        #endregion

        #region 寻找最近点对

        #endregion

        #region 大整数乘法

        #endregion

        #region 矩阵乘法

        #endregion

        #region 求解逆序对

        #endregion


        /*
         * 分治思想在算法和数据结构设计中的应用：二分查找、归并排序、快速排序、桶排序、树、堆、哈希表(解决Hash冲突间接应用分治)
         */

    }
}

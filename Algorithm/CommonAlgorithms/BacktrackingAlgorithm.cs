using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonAlgorithm
{
    /// <summary>
    /// 回溯算法：是一种通过穷举来解决问题的方法，它的核心思想是从一个初始状态出发，暴力搜索所有可能的解决方案，当遇到正确的解则将其记录，
    ///         直到找到解或者尝试了所有可能的选择都无法找到解为止。 分为尝试和回退两个部分（向前走，碰壁回头）。
    /// 尝试：从某个状态开始出发尝试找到正确的解。
    /// 回退：当算法在搜索过程中遇到某个状态无法继续前进或无法得到满足条件的解时，它会撤销上一步的选择，退回到之前的状态，并尝试其他可能的选择
    ///      回溯算法通常采用"深度优先搜索"来遍历空间，树的前序、中序、后序遍历就是回溯算法的一种体现。
    /// 优缺点：这种方法的优点在于能够找到所有可能的解决方案，而且在合理的剪枝操作下，具有很高的效率。
    ///        然而，在处理大规模或者复杂问题时，回溯算法的运行效率可能难以接受。
    /// </summary>
    internal static class BacktrackingAlgorithm
    {
        #region 回溯算法框架
        /* 回溯算法框架 */
        /*void Backtrack(State state, List<Choice> choices, List<State> res)
        {
            // 判断是否为解
            if (IsSolution(state))
            {
                // 记录解
                RecordSolution(state, res);
                // 不再继续搜索
                return;
            }
            // 遍历所有选择
            foreach (Choice choice in choices)
            {
                // 剪枝：判断选择是否合法
                if (IsValid(state, choice))
                {
                    // 尝试：做出选择，更新状态
                    MakeChoice(state, choice);
                    Backtrack(state, choices, res);
                    // 回退：撤销选择，恢复到之前的状态
                    UndoChoice(state, choice);
                }
            }
        }
        */
        #endregion

        #region N皇后问题
        /*
         * 根据国际象棋的规则，皇后可以攻击与同处一行、一列或一条斜线上的棋子。给定n个皇后和一个n*n大小的棋盘，
         * 寻找使得所有皇后之间无法相互攻击的摆放方案。
         */

        /// <summary>
        /// 求解 n 皇后
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<List<List<string>>> NQueens(int n)
        {
            // 初始化 n*n 大小的棋盘，其中 'Q' 代表皇后，'#' 代表空位
            List<List<string>> state = [];
            for (int i = 0; i < n; i++)
            {
                List<string> row = [];
                for (int j = 0; j < n; j++)
                {
                    row.Add("#");
                }
                state.Add(row);
            }
            bool[] cols = new bool[n]; // 记录列是否有皇后
            bool[] diags1 = new bool[2 * n - 1]; // 记录主对角线上是否有皇后
            bool[] diags2 = new bool[2 * n - 1]; // 记录次对角线上是否有皇后
            List<List<List<string>>> res = [];

            BacktrackQueen(0, n, state, res, cols, diags1, diags2);

            return res;
        }

        /// <summary>
        /// 回溯算法：n 皇后 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="n"></param>
        /// <param name="state"></param>
        /// <param name="res"></param>
        /// <param name="cols"></param>
        /// <param name="diags1"></param>
        /// <param name="diags2"></param>
        public static void BacktrackQueen(int row, int n, List<List<string>> state, List<List<List<string>>> res,
                bool[] cols, bool[] diags1, bool[] diags2)
        {
            // 当放置完所有行时，记录解
            if (row == n)
            {
                List<List<string>> copyState = [];
                foreach (List<string> sRow in state)
                {
                    copyState.Add(new List<string>(sRow));
                }
                res.Add(copyState);
                return;
            }
            // 遍历所有列
            for (int col = 0; col < n; col++)
            {
                // 计算该格子对应的主对角线和次对角线
                int diag1 = row - col + n - 1;
                int diag2 = row + col;
                // 剪枝：不允许该格子所在列、主对角线、次对角线上存在皇后
                if (!cols[col] && !diags1[diag1] && !diags2[diag2])
                {
                    // 尝试：将皇后放置在该格子
                    state[row][col] = "Q";
                    cols[col] = diags1[diag1] = diags2[diag2] = true;
                    // 放置下一行
                    BacktrackQueen(row + 1, n, state, res, cols, diags1, diags2);
                    // 回退：将该格子恢复为空位
                    state[row][col] = "#";
                    cols[col] = diags1[diag1] = diags2[diag2] = false;
                }
            }
        }
        #endregion

        #region 全排列问题
        /*
         * 1.输入一个整数数组，其中不包含重复元素，返回所有可能的排列。
         */

        /// <summary>
        /// 全排列I
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static List<List<int>> PermutationsI(int[] nums)
        {
            List<List<int>> res = [];
            Backtrack([], nums, new bool[nums.Length], res);
            return res;
        }

        /// <summary>
        /// 回溯算法：全排列 I
        /// </summary>
        /// <param name="state"></param>
        /// <param name="choices"></param>
        /// <param name="selected"></param>
        /// <param name="res"></param>
        public static void Backtrack(List<int> state, int[] choices, bool[] selected, List<List<int>> res)
        {
            // 当状态长度等于元素数量时，记录解
            if (state.Count == choices.Length)
            {
                res.Add(new List<int>(state));
                return;
            }
            // 遍历所有选择
            for (int i = 0; i < choices.Length; i++)
            {
                int choice = choices[i];
                // 剪枝：不允许重复选择元素
                if (!selected[i])
                {
                    // 尝试：做出选择，更新状态
                    selected[i] = true;
                    state.Add(choice);
                    // 进行下一轮选择
                    Backtrack(state, choices, selected, res);
                    // 回退：撤销选择，恢复到之前的状态
                    selected[i] = false;
                    state.RemoveAt(state.Count - 1);
                }
            }
        }


        /*
         * 2.其中不包含重复元素，返回所有可能的排列。
         */

        /// <summary>
        /// 全排列 II
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static List<List<int>> PermutationsII(int[] nums)
        {
            List<List<int>> res = [];
            Backtrack([], nums, new bool[nums.Length], res);
            return res;
        }

        /// <summary>
        /// 回溯算法：全排列 II
        /// </summary>
        /// <param name="state"></param>
        /// <param name="choices"></param>
        /// <param name="selected"></param>
        /// <param name="res"></param>
        public static void BacktrackII(List<int> state, int[] choices, bool[] selected, List<List<int>> res)
        {
            // 当状态长度等于元素数量时，记录解
            if (state.Count == choices.Length)
            {
                res.Add(new List<int>(state));
                return;
            }
            // 遍历所有选择
            HashSet<int> duplicated = [];
            for (int i = 0; i < choices.Length; i++)
            {
                int choice = choices[i];
                // 剪枝：不允许重复选择元素 且 不允许重复选择相等元素
                if (!selected[i] && !duplicated.Contains(choice))
                {
                    // 尝试：做出选择，更新状态
                    duplicated.Add(choice); // 记录选择过的元素值
                    selected[i] = true;
                    state.Add(choice);
                    // 进行下一轮选择
                    Backtrack(state, choices, selected, res);
                    // 回退：撤销选择，恢复到之前的状态
                    selected[i] = false;
                    state.RemoveAt(state.Count - 1);
                }
            }
        }
        #endregion

        #region 子集和问题
        /*
         * 1.给定一个正整数数组 nums 和一个目标正整数 target ，请找出所有可能的组合，使得组合中的元素和等于 target 。
         * 给定数组无重复元素，每个元素可以被选取多次。请以列表形式返回这些组合，列表中不应包含重复组合。
         */

        /// <summary>
        /// 求解子集和 I（包含重复子集）
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<List<int>> SubsetSumINaive(int[] nums, int target)
        {
            List<int> state = []; // 状态（子集）
            int total = 0; // 子集和
            List<List<int>> res = []; // 结果列表（子集列表）
            BacktrackSubAdd(state, target, total, nums, res);
            return res;
        }

        /// <summary>
        /// 回溯算法：子集和 I
        /// </summary>
        /// <param name="state"></param>
        /// <param name="target"></param>
        /// <param name="total"></param>
        /// <param name="choices"></param>
        /// <param name="res"></param>
        private static void BacktrackSubAdd(List<int> state, int target, int total, int[] choices, List<List<int>> res)
        {
            // 子集和等于 target 时，记录解
            if (total == target)
            {
                res.Add(new List<int>(state));
                return;
            }
            // 遍历所有选择
            for (int i = 0; i < choices.Length; i++)
            {
                // 剪枝：若子集和超过 target ，则跳过该选择
                if (total + choices[i] > target)
                {
                    continue;
                }
                // 尝试：做出选择，更新元素和 total
                state.Add(choices[i]);
                // 进行下一轮选择
                BacktrackSubAdd(state, target, total + choices[i], choices, res);
                // 回退：撤销选择，恢复到之前的状态
                state.RemoveAt(state.Count - 1);
            }
        }


        /// <summary>
        /// 求解子集和 I（去重复子集）
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<List<int>> SubsetSumI(int[] nums, int target)
        {
            List<int> state = []; // 状态（子集）
            Array.Sort(nums); // 对 nums 进行排序
            int start = 0; // 遍历起始点
            List<List<int>> res = []; // 结果列表（子集列表）
            BacktrackSubAddII(state, target, nums, start, res);
            return res;
        }

        /// <summary>
        /// 回溯算法：子集和 I(去重复子集)
        /// </summary>
        /// <param name="state"></param>
        /// <param name="target"></param>
        /// <param name="choices"></param>
        /// <param name="start"></param>
        /// <param name="res"></param>
        public static void BacktrackSubAddII(List<int> state, int target, int[] choices, int start, List<List<int>> res)
        {
            // 子集和等于 target 时，记录解
            if (target == 0)
            {
                res.Add(new List<int>(state));
                return;
            }
            // 遍历所有选择
            // 剪枝二：从 start 开始遍历，避免生成重复子集
            for (int i = start; i < choices.Length; i++)
            {
                // 剪枝一：若子集和超过 target ，则直接结束循环
                // 这是因为数组已排序，后边元素更大，子集和一定超过 target
                if (target - choices[i] < 0)
                {
                    break;
                }
                // 尝试：做出选择，更新 target, start
                state.Add(choices[i]);
                // 进行下一轮选择
                BacktrackSubAddII(state, target - choices[i], choices, i, res);
                // 回退：撤销选择，恢复到之前的状态
                state.RemoveAt(state.Count - 1);
            }
        }

        /*
         * 2.给定一个正整数数组 nums 和一个目标正整数 target ，请找出所有可能的组合，使得组合中的元素和等于 target 。
         * 给定数组可能包含重复元素，每个元素只可被选择一次。请以列表形式返回这些组合，列表中不应包含重复组合。
         */
        /// <summary>
        /// 求解子集和 II（有重复元素）
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<List<int>> SubsetSumII(int[] nums, int target)
        {
            List<int> state = []; // 状态（子集）
            Array.Sort(nums); // 对 nums 进行排序
            int start = 0; // 遍历起始点
            List<List<int>> res = []; // 结果列表（子集列表）
            BacktrackSubAddIII(state, target, nums, start, res);
            return res;
        }
        /// <summary>
        /// 回溯算法：子集和 II（有重复元素）
        /// </summary>
        /// <param name="state"></param>
        /// <param name="target"></param>
        /// <param name="choices"></param>
        /// <param name="start"></param>
        /// <param name="res"></param>
        public static void BacktrackSubAddIII(List<int> state, int target, int[] choices, int start, List<List<int>> res)
        {
            // 子集和等于 target 时，记录解
            if (target == 0)
            {
                res.Add(new List<int>(state));
                return;
            }
            // 遍历所有选择
            // 剪枝二：从 start 开始遍历，避免生成重复子集
            // 剪枝三：从 start 开始遍历，避免重复选择同一元素
            for (int i = start; i < choices.Length; i++)
            {
                // 剪枝一：若子集和超过 target ，则直接结束循环
                // 这是因为数组已排序，后边元素更大，子集和一定超过 target
                if (target - choices[i] < 0)
                {
                    break;
                }
                // 剪枝四：如果该元素与左边元素相等，说明该搜索分支重复，直接跳过
                if (i > start && choices[i] == choices[i - 1])
                {
                    continue;
                }
                // 尝试：做出选择，更新 target, start
                state.Add(choices[i]);
                // 进行下一轮选择
                BacktrackSubAddIII(state, target - choices[i], choices, i + 1, res);
                // 回退：撤销选择，恢复到之前的状态
                state.RemoveAt(state.Count - 1);
            }
        }

        #endregion
    }
}

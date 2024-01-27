using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithm
{
    internal static class SortAlgorithms
    {
        #region Bubble Sort
        /// <summary>
        /// 冒泡算法：从第一个数开始依次和后一个比较，大的就往后冒，过程像水中冒泡一样，所以叫冒泡排序
        /// 时间复杂度：O(n^2)
        /// 空间复杂度：O(1)
        /// 稳定性：稳定
        /// </summary>
        /// <param name="sortList"></param>
        public static void BubbleSort(int[] sortList)
        {
            int listLength = sortList.Length;
            for (int i = 0; i < listLength - 1; i++)
            {
                for (int j = 0; j < listLength - i - 1; j++)
                {
                    if (sortList[j] > sortList[j + 1])
                    {
                        (sortList[j], sortList[j + 1]) = (sortList[j + 1], sortList[j]);
                    }
                }
                Console.WriteLine($"第{i + 1}次排序：" + string.Join(" ", sortList));
            }
        }
        #endregion

        #region Selection Sort
        /// <summary>
        /// 选择排序：通过选择的方式每次选择最小的值依次和第一个开始交换来达到排序的目的，所以称作选择排序
        /// 时间复杂度：O(n^2)
        /// 空间复杂度：O(1)
        /// 稳定性：不稳定
        /// </summary>
        /// <param name="sortList"></param>
        public static void SelectionSort(List<int> sortList)
        {
            int listLength = sortList.Count();
            for (int i = 0; i < listLength - 1; i++)
            {
                int min = i;//记录最小值
                for (int j = i + 1; j < listLength - 1; j++)
                {
                    if (sortList[j] < sortList[min])
                    {
                        min = j;// 获取最小的下标并赋值
                    }
                }
                (sortList[i], sortList[min]) = (sortList[min], sortList[i]); // 交换元素
                Console.WriteLine($"第{i + 1}次排序：" + string.Join(" ", sortList));
            }
        }
        #endregion

        #region Insertion Sort
        /// <summary>
        /// 插入排序：从序列第2位开始，在i-1位已经有序情况下，将第i位插入到合适的位置，故名插入排序
        /// 时间复杂度：O(n^2)
        /// 控件复杂度：O(1)
        /// 稳定性：稳定
        /// </summary>
        /// <param name="sortList"></param>
        public static void InsertionSort(int[] sortList)
        {
            int listLength = sortList.Length;
            for (int i = 1; i <= listLength - 1; i++)// 从第二个元素开始遍历
            {
                int temp = sortList[i];// 定义一个变量缓存当前值
                int j = i - 1; // 获取前面i-1个序列末尾索引
                while (j >= 0)// 逆序判断前面i-1个数
                {
                    if (temp > sortList[j]) // 如果比前面的数大则不插入跳出循环(因为前面的数已经有序)
                    {
                        break;
                    }
                    // 如果发现缓存数比前面的数小
                    sortList[j + 1] = sortList[j]; //将前面的数往后移动
                    j--;// 继续向前移动
                }
                sortList[j + 1] = temp;// 将缓存值插入到对应的位置(使用while循环可以优化只执行一次插入)
                Console.WriteLine($"第{i + 1}次排序：" + string.Join(" ", sortList));
            }
        }
        #endregion

        #region Recursion Merge Sort
        /// <summary>
        /// 归并排序：利用用分治分思想实现排序，将大的序列拆分为小的分组实现排序然后再合并；采用递归对序列进行拆分，采用合并对序列进行合并
        /// 时间复杂度：O(nlogn)
        /// 空间复杂度：O(n)
        /// 稳定性：稳定
        /// </summary>
        /// <param name="sortList"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void RecursionMergeSort(int[] sortList, int start, int end)
        {
            if (start == end)
            {
                return;
            }
            int mid = (start + end) / 2;
            RecursionMergeSort(sortList, start, mid);
            RecursionMergeSort(sortList, mid + 1, end);
            Merge(sortList, start, mid, end);
        }
        private static void Merge(int[] sortList, int start, int mid, int end)
        {
            // 执行合并的函数（将两个排好序的分组合并为一个有序序列）
            // 前提表示列表的 start 到 mid 以及 mid+1 到 end 已经排好序了
            List<int> tempList = new List<int>();
            int lef = start;// 左边分组起始点
            int rig = mid + 1;// 右边分组起始点
            while (lef <= mid && rig <= end)//如果没有移动到各自分组的终点则继续
            {
                // 按顺序将两个分组中小的值依次存入临时列表里
                if (sortList[lef] <= sortList[rig])
                {
                    tempList.Add(sortList[lef]);
                    lef++;// 左分组指针移动
                }
                else
                {
                    tempList.Add(sortList[rig]);
                    rig++;// 右分组指针移动
                }
            }
            tempList.AddRange(sortList[lef..(mid + 1)]);
            tempList.AddRange(sortList[rig..(end + 1)]);
            for (int i = start; i <= end; i++)
            {
                // 复制到原序列中
                sortList[i] = tempList[i - start];
            }
            Console.WriteLine($"d{start},e{end}: 合并结果：{string.Join(" ", tempList)}");
        }
        #endregion

        #region Bucket Sort
        /// <summary>
        /// 桶排序：利用分治思想，生成一些桶，让数字散落在对应桶中，保证后续桶中的数字都比前一个桶中的数字都大，然后再在各个桶中分别执行排序，最后再进行桶的拼接
        /// 备注：桶排序是一种上层排序，需要搭配基础排序，基础排序需要根据数据规模、数据分布、时间复杂度和空间复杂度等因素进行选择
        /// 时间复杂度：O(n+k)(k：序列长度)
        /// 空间复杂度：O(n+k)
        /// 稳定性：稳定
        /// </summary>
        /// <param name="sortList"></param>
        public static void BucketSort(int[] sortList)
        {
            // 取出最大最小值
            int min = sortList.Min();
            int max = sortList.Max();
            // 定义桶（用3个桶）
            int bucketCount = 3;
            Dictionary<int, List<int>> bucket = new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() },
                { 1, new List<int>() },
                { 2, new List<int>() },
            };// 定义桶

            // 每个桶中该有多少个元素
            int perBucket = (max - min + bucketCount) / bucketCount;// 计算每个桶中不同数字的元素个数
            // 把元素分到合适的桶中
            foreach (var num in sortList)
            {
                int bucketIndex = (num - min) / perBucket;
                bucket[bucketIndex].Add(num);
            }

            // 遍历每个桶，在桶中使用选择排序[import]
            for (int i = 0; i < bucket.Count(); i++)
            {
                SelectionSort(bucket[i]);
            }

            //将桶中排好序的元素依次放回原列表
            int idx = 0;
            for (int i = 0; i < bucket.Count; i++)
            {
                foreach (var item in bucket[i])
                {
                    sortList[idx] = item;
                    idx++;
                }
                Console.WriteLine(string.Join(" ", bucket[i]));
            }
            Console.WriteLine(string.Join(" ", sortList));
        }
        #endregion

        #region Counting Sort
        /// <summary>
        /// 计数排序：利用Hash表的设计思想，需要预先生成区间大小为序列中值大小的区间数组，遍历时会对元素进行计数操作，最后根据技术将序列输出
        /// 备注：计数排序属于桶排序的一种变体，计数排序效率高，但对数据类型和范围有一定要求，适用于范围不大且重复值多的序列
        /// 时间复杂度：O(n+k)
        /// 空间复杂度：O(k)
        /// 稳定性：稳定
        /// </summary>
        /// <param name="sortList"></param>
        public static void CountingSort(List<int> sortList)
        {
            //int listLength = sortList.Count();
            int countingLength = sortList.Max() + 1;// 为什么要加1[？]
            List<int> counter = Enumerable.Repeat(0, countingLength + 1).ToList();//new List<int>(countingLength+1);
            foreach (var val in sortList)
            {
                counter[val] += 1;// 对应计数器执行加1
            }
            Console.WriteLine(string.Join(" ", counter));
            int count = 0;
            // 只要计数器中记录有值，就继续迭代计算
            for (int i = 0; i < countingLength; i++)
            {
                while (counter[i] > 0) // 对应数值计数大于0就继续
                {
                    counter[i]--; // 将计数器中对应计数减一
                    sortList[count] = i;// 塞入原来的列表中
                    count++;
                }
            }
            Console.WriteLine(string.Join(" ", sortList));
        }
        #endregion

        #region Radix Sort
        /// <summary>
        /// 基数排序：基于位数进行排序，依次根据个十百千万...进行位数上的排序，并最终得到排好的序列
        /// 备注：基数排序是桶排序的一种变体，需要一个0~9的索引桶，按位数依次放入索引桶中的对应位置，顺序放回再进行下一位如此操作直至最高位数的值结束
        /// 时间复杂度：O(n*k)
        /// 空间复杂度：O(n+k)
        /// 稳定性：稳定
        /// </summary>
        /// <param name="sortList"></param>
        public static void RadixSort(List<int> sortList)
        {
            int baseNum = 1;// 基数代表个位
            int max = sortList.Max();
            while (baseNum < max)
            {
                Dictionary<int, List<int>> bucket = new Dictionary<int, List<int>>();
                // 初始化基数桶
                for (int i = 0; i < 10; i++)
                {
                    bucket[i] = new List<int>();
                }
                // 遍历序列根据数位进行分桶
                foreach (int num in sortList)
                {
                    int radix = num / baseNum % 10;
                    bucket[radix].Add(num);
                }
                // 按顺序塞回原列表中
                int idx = 0;
                for (int i = 0; i < 10; i++)
                {
                    foreach (var val in bucket[i])
                    {
                        sortList[idx] = val;
                        idx++;
                    }
                }
                // 打印当前原列表结果
                Console.WriteLine(string.Join(" ", sortList));
                baseNum *= 10;// 继续迭代计算下一个数位
            }
        }
        #endregion

        #region Quick Sort
        /// <summary>
        /// 快速排序：利用二分的思想，找到一个基准点，把小于基准点的和大于基准点的数分开，然后将两部分再分别执行快速排序，相对于传统排序其时间复杂度
        /// 更低，所以被称为快速排序
        /// 时间复杂度：O(nlogn)
        /// 空间复杂度：O(logn)
        /// 稳定性：不稳定
        /// </summary>
        /// <param name="sortList"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void QuickSort(List<int> sortList, int start, int end)
        {
            // 只有一个数就返回
            if (start >= end)
            {
                return;
            }
            // 执行第一次排序获取基准数下标
            int pivot = QuickSortPivot(sortList, start, end);
            // 递归执行左边部分
            QuickSort(sortList, start, pivot - 1);
            // 递归执行右边部分
            QuickSort(sortList, pivot + 1, end);
        }

        /// <summary>
        /// 在序列中找到基准数下标(指针)，将所有小于等于它的放到它的左边，大于它的放到它的右边
        /// </summary>
        /// <param name="sortList"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static int QuickSortPivot(List<int> sortList, int start, int end)
        {
            Random random = new Random();
            (sortList[start], sortList[random.Next(start, end)]) = (sortList[random.Next(start, end)], sortList[start]);
            int pivot = start; // 选取第一位为基准数
            int lef = start + 1;// 代表基准数左边界下标
            // 将小于基准数的数放到左边（大于的不处理，会全部在右边）
            // 保证lef下标以前的数都是小于基准数的数
            for (int i = start + 1; i < end + 1; i++)
            {
                if (sortList[i] <= sortList[pivot])// 当前数小于等于基准数
                {
                    // 和基准数左边界的数交互
                    (sortList[i], sortList[lef]) = (sortList[lef], sortList[i]);
                    // 更新左边界下标继续迭代交换
                    lef++;
                }
            }
            // 将基准数和最右边的数交换
            (sortList[pivot], sortList[lef - 1]) = (sortList[lef - 1], sortList[pivot]);
            pivot = lef - 1;// 更新基准数下标
            // 打印本次排序结果
            Console.WriteLine($"基准数：{sortList[pivot]}，左边：{string.Join(" ", sortList.ToArray()[start..pivot])}，右边：{string.Join(" ", sortList.ToArray()[(pivot + 1)..(end + 1)])}");
            return pivot;
        }
        #endregion

        #region Shell Sort
        /// <summary>
        /// 希尔排序：由希尔提出，所以被称为希尔排序，是一种改进后的插入排序
        /// 备注：根据序列选择一定增量，将序列分组然后执行插入排序，再依次降低增量重复过程，直至增量为1
        /// 时间复杂度：O(nlogn)
        /// 空间复杂度：O(1)
        /// 稳定性：不稳定
        /// </summary>
        /// <param name="sortList"></param>
        public static void ShellSort(List<int> sortList)
        {
            int listLength = sortList.Count();
            int increment = listLength / 2; // 第一次排序的增量
            int times = 1;// 记录排序次数
            // 每隔一个增量值的序列执行插入排序
            while (increment > 0)// 只要增量大于0就继续
            {
                for (int i = increment; i < listLength - 1; i++)
                {
                    int min = sortList[i];//选取第一个作为最小值
                    int j = i;// 记录增量值下标
                    while (j >= increment)
                    {
                        // 将小的值插入到分组序列前面
                        if (min <= sortList[j - increment])
                        {
                            sortList[j] = sortList[j - increment];
                        }
                        else
                        {
                            break;
                        }
                        j -= increment;// 根据增量迭代执行
                    }
                    sortList[j] = min;
                }
                Console.WriteLine($"第{times++}次排序：" + string.Join(" ", sortList));
                increment /= 2;
            }
        }
        #endregion

        #region Heap Sort
        /// <summary>
        /// 堆排序：利用了堆的性质进行排序，所以被称为堆排序
        /// 备注：堆是一个完全二叉树，大顶堆是根节点最大的完全二叉树，小顶堆是根节点最小的完全二叉树，构造成堆的树层序遍历后可以得到一个有序序列
        /// 时间复杂度：O(nlogn)
        /// 空间复杂度：O(1)
        /// 稳定性：不稳定
        /// </summary>
        /// <param name="sortList"></param>
        public static void HeapSort(List<int> sortList)
        {
            // 假设堆下标从1开始，从后往前构建堆需要将0下标排除(-1占位)
            List<int> heap = new List<int>() { -1 };
            heap.AddRange(sortList);
            // 定义堆顶元素下标
            int root = 1;
            // 获取堆元素个数
            int length = heap.Count;
            // 逆序枚举堆中的元素(从最后一个元素)(实际上从lenth/2个元素就可以)
            for (int i = length; i > root - 1; i--)//length / 2
            {
                // 自底向上构造堆
                MaxHeapify(heap, i, length - 1);
            }
            // 构造完以后将堆顶元素和最后一个元素交换即可
            for (int i = length - 1; i > root; i--)
            {
                (heap[i], heap[root]) = (heap[root], heap[i]);
                // 保证剩余堆的合法性(剩余元素重新构建堆)
                MaxHeapify(heap, root, i - 1);
            }
            // 打印排好的序列
            Console.WriteLine(string.Join(" ", heap.ToArray()[root..]));
        }

        /// <summary>
        /// 构造一个大顶堆，实现下沉操作，同时表示start到end这个区间组成一个合法的堆（start为堆的根节点编号）
        /// </summary>
        /// <param name="sortList"></param>
        private static void MaxHeapify(List<int> heap, int start, int end)
        {
            // 令lefSon为start的左子树根
            int leftSon = start * 2;
            // 如果左子树存在
            while (leftSon <= end)
            {
                // 则取左子树根和右子树根中两者的较大值的下标缓存到leftSon中
                if (leftSon + 1 <= end && heap[leftSon + 1] > heap[leftSon])
                {
                    leftSon++;
                }
                // 如果子节点的值大于根节点的值，则将根节点和子节点进行交换（根节点下沉）
                if (heap[leftSon] > heap[start])
                {
                    (heap[start], heap[leftSon]) = (heap[leftSon], heap[start]);// 根节点下沉
                    (start, leftSon) = (leftSon, leftSon * 2);// 子节点迭代执行下沉操作
                }
                else // 如果子节点的值小于等于根节点的值（证明堆构造好了）
                {
                    break;
                }
            }
        }

        #endregion
    }
}

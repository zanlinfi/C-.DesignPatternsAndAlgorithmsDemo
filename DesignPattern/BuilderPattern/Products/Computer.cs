using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Products
{
    internal class Computer
    {
        // 电脑零件各部件集合
        private List<string> listPart = new();


        public void AddPart(string part)
        {
            listPart.Add(part);
        }


        public void ShowComputer()
        {
            listPart.ForEach(part =>
            {
                Console.WriteLine($"正在安装：{part}");
            });

        }
    }
}

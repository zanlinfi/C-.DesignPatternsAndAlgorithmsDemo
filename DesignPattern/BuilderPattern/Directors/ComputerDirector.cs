using BuilderPattern.Builders.IBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Directors
{
    /// <summary>
    /// 封装稳定创建对象的过程（稳定的创建各个对象）
    /// </summary>
    internal class ComputerDirector
    {

        /// <summary>
        /// 创建电脑对象
        /// </summary>
        /// <param name="builder"></param>
        public IComputerBuilder BuildComputer(IComputerBuilder builder)
        {
            builder.BuildCpu();
            builder.BuildGpu();
            builder.BuildDisk();
            builder.BuildMemory();
            builder.BuildSystem();
            builder.BuildScreen();
            return builder;

        }
    }
}

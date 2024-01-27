using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Factories.Factory
{
    /// <summary>
    /// 采用主构造函数写法书写特性，给目标类增加额外特性
    /// </summary>
    /// <param name="oper"></param>
    internal class OperToFactoryAttribute(string oper) : Attribute
    {
        public string Oper { get=>oper; }// 操作符值提前定义写好依附在类上，不需要提供set方法
       
    }
}

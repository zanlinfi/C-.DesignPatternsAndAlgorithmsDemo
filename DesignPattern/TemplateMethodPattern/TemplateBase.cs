using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    internal abstract class TemplateBase
    {
       private void Step1()
        {
            Console.WriteLine("步骤1");
        }

        /// <summary>
        /// 这个方法就是钩子函数，子类根据具体情况去实现
        /// </summary>
        public virtual void Step2()
        {
            Console.WriteLine("步骤2");
        }

        private void Step3()
        {
            Console.WriteLine("步骤3");
        }

        public void GetResult()
        {
            Step1();
            Step2();
            Step3();
        }
    }
}

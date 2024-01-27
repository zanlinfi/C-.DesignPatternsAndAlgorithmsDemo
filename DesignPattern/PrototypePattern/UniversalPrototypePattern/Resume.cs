using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.UniversalPrototypePattern
{
    internal class Resume(int id, string name) : AbsResumePrototype(id, name)
    {
        public override AbsResumePrototype Clone()
        {
            // MemberwiseClone：浅克隆
            // 值类型：全部复制一遍
            // 引用类型： 只复制其引用，并不复制对象本身
            return this.MemberwiseClone() as Resume;
        }
    }
}

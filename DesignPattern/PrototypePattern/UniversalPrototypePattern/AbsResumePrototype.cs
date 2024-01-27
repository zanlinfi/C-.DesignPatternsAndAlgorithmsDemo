using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.UniversalPrototypePattern
{
    internal abstract class AbsResumePrototype(int id, string name)
    {
        public int ID { get; set; } = id;
        public string Name { get; set; } = name;

        public abstract AbsResumePrototype Clone();
    }
}

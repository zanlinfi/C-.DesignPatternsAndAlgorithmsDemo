using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.DeepCloneInC_
{
    internal class WorkExperience : ICloneable
    {
        public string Company { get; set; }
        public string WorkTime { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

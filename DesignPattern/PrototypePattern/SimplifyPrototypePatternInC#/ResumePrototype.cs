using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.SimplifyPrototypeInC_
{
    /// <summary>
    /// 实现C#简化的ICloneable接口，来简化原型模式的设计，实现克隆操作
    /// </summary>
    internal class ResumePrototype : ICloneable
    {
        public int Age { get; set; }
        public char Gender { get; set; }
        public string Name  { get; set; }
        public string Company  { get; set; }
        public string WorkTime  { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void SetInfo(int age, string name, char gender)
        {
            Age = age;
            Name = name;
            Gender = gender;
        }


        public void SetWorkExperience(string workTime,string company)
        {
            WorkTime = workTime;
            Company = company;
        }

        public void ShowResume()
        {
            Console.WriteLine($"{Name},{Age},{Gender},{Company}");
        }
    }
}

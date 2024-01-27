using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.DeepCloneInC_
{
    /// <summary>
    /// 深拷贝要求引用类也得实现MemberwiseClone方法，
    /// </summary>
    internal class ResumeDeep() : ICloneable
    {
        public int Age { get; set; }
        public char Gender { get; set; }
        public string Name  { get; set; }
        //public string Company  { get; set; }
        //public string WorkTime  { get; set; }
        private WorkExperience _workExperience = new();

        //public ResumeDeep()
        //{
        //    _workExperience = new WorkExperience();
        //}

        /// <summary>
        /// 私有化一个内部的引用类型构造函数，用于获取引用类型的Copy
        /// </summary>
        /// <param name="workExperience"></param>
        private ResumeDeep(WorkExperience workExperience) : this()
        {
            _workExperience = workExperience.Clone() as WorkExperience;
        }
        public object Clone()
        {
            // 调用端就不能再使用 MemberwiseClone，否则就无法实现深克隆
            // return MemberwiseClone();
            // 创建对象时将引用类型也Copy一份
            ResumeDeep resume = new(_workExperience);
            resume.Age = Age;
            resume.Gender = Gender;
            resume.Name = Name;
            return resume;
        }

        public void SetInfo(int age, string name, char gender)
        {
            Age = age;
            Name = name;
            Gender = gender;
        }


        public void SetWorkExperience(string workTime,string company)
        {
            _workExperience.WorkTime = workTime;
            _workExperience.Company = company;
        }

        public void ShowResume()
        {
            Console.WriteLine($"{Name},{Age},{Gender},{_workExperience.Company},{_workExperience.WorkTime}");
        }
    }
}

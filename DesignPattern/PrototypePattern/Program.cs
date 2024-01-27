// See https://aka.ms/new-console-template for more information
/// 原型模式：方便创建多个对象，节约效率
/// 浅拷贝：只拷贝值类型，应用类型拷贝的是其引用
/// 深拷贝：值类型和引用类型的具体值都会拷贝
/// 一般意义上的拷贝都为浅拷贝：若涉及到深拷贝，最好的策略是利用反射和序列化的策略去实现真正意义上的深拷贝
using PrototypePattern.DeepCloneInC_;
using PrototypePattern.SimplifyPrototypeInC_;
using PrototypePattern.UniversalPrototypePattern;

#region Universal Prototype Memberwise Clone
Resume resumePrototype = new(1,"张三");
Resume resume1 = resumePrototype.Clone() as Resume;
Console.WriteLine($"1:{resumePrototype.GetHashCode()}, 2:{resume1.GetHashCode()}; value:{resume1.Name}");
#endregion

Console.WriteLine("======================================================================================");

#region Prototype Pattern In C#
ResumePrototype resumeSimple = new();
resumeSimple.SetInfo(20,"张三",'男');
resumeSimple.SetWorkExperience("2021-2023","test company");
ResumePrototype resumeSimple1 = resumeSimple.Clone() as ResumePrototype;
resumeSimple.ShowResume();
resumeSimple1.ShowResume();
#endregion
            
Console.WriteLine("======================================================================================");

#region Deep Clone In C#
ResumeDeep resumedp = new();
resumedp.SetInfo(20, "张三", '男');
resumedp.SetWorkExperience("2021-2023", "test company");
ResumeDeep resumedp1 = resumedp.Clone() as ResumeDeep;
resumedp1.SetWorkExperience("2021-2023", "other");
resumedp.ShowResume();
resumedp1.ShowResume();

// 但是一旦涉及到引用类型的嵌套就需要递归实现深拷贝，是有很大弊端的
// 最好的深拷贝的策略时：利用反射和序列化来实现对象的深拷贝
#endregion
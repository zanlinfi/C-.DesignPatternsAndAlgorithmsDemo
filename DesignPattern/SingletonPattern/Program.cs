// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using SingletonPattern;


// hanger singleton call [not recommend]
HangerSingleton hangerSingleton = HangerSingleton.Instance;
HangerSingleton hangerSingleton2 = HangerSingleton.Instance;
Console.WriteLine($"{hangerSingleton.GetHashCode()}；{hangerSingleton2.GetHashCode()}；");

// lazy singlton call[recommend]
LazySingleton lazySingleton = LazySingleton.GetLazySingleton();
LazySingleton lazySingleton2 = LazySingleton.GetLazySingleton();
Console.WriteLine($"{lazySingleton.GetHashCode()}；{lazySingleton2.GetHashCode()}；");

for (int i = 0; i < 10; i++)
{
    //创建10个多线程测试，懒汉单例
    new Thread(() =>Console.WriteLine(LazySingleton.GetLazySingleton().GetHashCode())).Start();
}

//conclusion： 
//饿汉单例：程序一加载就创建对象
//懒汉单例：只有调用时才会创建对象，节约了资源

// 反射破坏单例
ReflectionBreakSingleton.BreakSingleton();
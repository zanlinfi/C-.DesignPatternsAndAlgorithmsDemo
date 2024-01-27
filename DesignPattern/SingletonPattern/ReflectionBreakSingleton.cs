using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    internal class ReflectionBreakSingleton
    {
        public static void BreakSingleton()
        {
           //0.拿到单例对象（正确获取创建）
           LazySingleton lazySingleton1 = LazySingleton.GetLazySingleton();
           //LazySingleton lazySingleton2 = LazySingleton.GetLazySingleton();
           //LazySingleton lazySingleton3 = LazySingleton.GetLazySingleton();

            //1.通过反射破坏单例：通过反射调用私有构造函数
            //Type? lazySingletonType2 = Type.GetType("SingletonPattern.LazySingleton");
            Type lazySingletonType = typeof(LazySingleton);

            //2.获取私有构造函数
            // 拿到私有的构造函数，拿到关于实例对象的
            ConstructorInfo[] ctors =  lazySingletonType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);

            //3.调用Invoke执行构造函数，获取对象(反射破坏了单例)
            LazySingleton? laztSingletonReflect = ctors[0].Invoke(null) as LazySingleton;

            //4.解决办法，私有构造函数中抛异常防止反射调用

            //5.破坏4方案，全部使用反射创建对象
            LazySingleton? laztSingletonReflect2 = ctors[0].Invoke(null) as LazySingleton;
            LazySingleton? laztSingletonReflect3 = ctors[0].Invoke(null) as LazySingleton;

            //6.解决5方案，使用标记位 

            //7.针对方法6，进行反射破坏：在第二次创建对象前将标志位改为false
            //FieldInfo[] fields = lazySingletonType.GetFields();
            //7.1拿到字段
            FieldInfo? isOkField = lazySingletonType.GetField("_isOk",BindingFlags.NonPublic | BindingFlags.Static);
            //7.2给字段赋值
            isOkField?.SetValue("_isOk",false);
            //7.3调用私有构造函数获取实例
            LazySingleton? laztSingletonReflect4 = ctors[0].Invoke(null) as LazySingleton;

            Console.WriteLine($@"normal singleton:{laztSingletonReflect}\n break singleton:{laztSingletonReflect4}");
            Console.ReadKey();

        }
    }
}

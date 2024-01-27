using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 恶汉单例：还没调用就已经被准备好了，也会浪费资源，所以不太好【不推荐】
    /// </summary>
    internal class HangerSingleton
    {
        //1.私有化构造函数
        private HangerSingleton()
        {

        }

        //2.创建一个唯一对象(唯一对象最好就是静态的)
        //private: 迪米特法则，没有必要暴露给外部的成员就写成private
        //static: 静态成员,保证内存唯一性
        //readonly: 不允许修改
        private static readonly HangerSingleton _instance = new HangerSingleton();

        //3.使用属性提供给外界获取唯一对象
        public static HangerSingleton Instance { get { return _instance; } }
    }

    /// <summary>
    /// 懒汉单例：内部静态类使得恶汉单例，实现内部懒加载【推荐】
    /// 
    /// </summary>
    public class HangerSingletonStatic
    {
        //1.私有化构造函数
        //4.声明锁对象防止多线程下单例被破坏
        private static readonly object objLock = new();
        private HangerSingletonStatic()
        {
            //4.1将只要是反射创建的对象统一认为不合法，通通抛异常
            lock (objLock)
            {
                // 直接抛异常
                throw new Exception("遭遇到反射破坏程序单例异常");
            }
        }

        //2.在内部类中实现懒汉单例获取（内部类的懒加载）
        //内部静态类中的饿汉单例不会跟随外部类一起加载的内存中（只有在外部调用属性访问时，才会加载内部成员）
        //某些程度上解决了懒汉单例的部分问题，不过依然存在反射破坏问题，只是没有多线程破坏问题
        private static class StaticInnerClass
        {
            public static readonly HangerSingletonStatic _instanceStatic = new HangerSingletonStatic();
        }

        // 3.使用属性提供给外界获取唯一对象
        public static HangerSingletonStatic InstanceStatic { get { return StaticInnerClass._instanceStatic; } }
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 懒汉单例：需要时再创建，不会造成资源的浪费【推荐】
    /// 懒汉单例会有线程安全问题：一般需要加锁防护
    /// </summary>
    internal class LazySingleton
    {
        // 1. 私有构造函数
        // 标记位：防止纯反射创建对象破坏单例
         private static bool _isOk = false;
        private LazySingleton()
        {
           //私有构造函数内部增加逻辑，防止反射获取破坏单例
           //lock：考虑多线程情况
           lock (objLock)
            {   
                // 如果此时实例已经被创建，而私有方被调用，则证明有反射破坏单例
                // if判断为真时，表明有反射搞破坏
                // 一旦程序中有一个对象被创建，则后续再使用反射创建，都会抛异常
                // 但是，如果破坏者全部使用反射创建对象，则程序中的new没有被执行，则instance永远为null(反射依然可以破坏程序)
                if (_instance is not null)
                {
                    // 直接抛异常
                    throw new Exception("遭遇到反射破坏程序单例异常");
                }

                // 使用标记位的方式防止纯反射创建对象破坏单例
                // 第一次反射进入，可反射创建对象
                if (!_isOk)
                {
                    _isOk = true;
                }
                // 后续的反射再进入都会抛异常
                else
                {
                   throw new Exception("遭遇多个纯反射创建对象破坏程序单例异常");
                }

                // 如果不考虑即使使用反射也只能创建一次单例（将所有反射操作视为非法的）
                // 那么只要调用了私有构造函数就抛异常而不做判断
                //throw new Exception("遭遇到反射破坏程序单例异常");

            }
        }

        // 2.声明静态字段，存储对象实例
        // 不写readonly因为后续赋值要在方法中
        // [ThreadStatic]：可以使用线程静态特性来代替加锁
        //volatile：用于防止指令重排（将变量放入主存，防止多线程模式下读取内存时更新不及时，导致创建对象指令重排）
        private static volatile LazySingleton? _instance;
        //4.声明锁对象防止多线程下单例被破坏
        private static readonly object objLock = new();

        // 3.通过方法创建对象返回
        public static LazySingleton GetLazySingleton()
        {
            //3.1调用之前要判断是否存在实例，没有才创建
            //3.1.1外部判断：用于过滤线程，防止所有的线程都去访问锁消耗锁资源【节约资源】
            //（当有一个线程创建对象成功，后面所有的线程再判断时就，对象就不为空，不会再进入if分支，消耗锁资源）
            if (_instance is null)
            {
                //3.1.2加锁防止多线程，造成单例失效
                lock (objLock)
                {
                    // 双判断：双重锁定
                    // 3.1.3内部判断：针对拿到锁的线程，判断实例是否存在
                    if (_instance is null)
                    {
                        // new创建对象：
                        // 1.内存中开辟空间
                        // 2.执行构造函数创建对象
                        // 3.把空间指向我们创建的对象
                        // 正常执行情况：123，返回正确对象
                        // 异常执行情况：132（指令重排，会直接执行三让空间指向一个不存在的对象(错误对象)）[极端情况]
                        _instance = new LazySingleton();
                    }
                }
            }
            //3.2有了就返回之前的
            return _instance;
        }
    }
}

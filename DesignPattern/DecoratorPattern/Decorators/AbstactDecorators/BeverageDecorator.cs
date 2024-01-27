using DecoratorPattern.Components.IBaseComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Decorators.AbstactDecorators
{
    /// <summary>
    /// 装饰器抽象父类，用于给基础饮料添加额外配料作为装饰，并返回其价格 [Core]
    /// </summary>
    /// <param name="beverage"></param>
    internal abstract class BeverageDecorator : IBaseBeverage
    {
        // 添加父类引用
        private IBaseBeverage baseBeverage;
        
        /// <summary>
        /// 给饮料添加配料
        /// </summary>
        /// <param name="beverage"></param>
        public void AddBatching(IBaseBeverage beverage)
        {
             this.baseBeverage = beverage;
        }

        //返回配料的价格
        public virtual double Cost() // 此方法有默认实现不能使用abstract
        {
            return baseBeverage.Cost();
        }
    }
}

using DecoratorPattern.Decorators.AbstactDecorators;

namespace DecoratorPattern.Decorators
{
    internal class PearlBatching : BeverageDecorator
    {
        private static double money = 7;

        /// <summary>
        /// 配料返回本身价格的同时要加上父类已有的价格（父类的价格包括了在此之前累计的其他配料的价格）
        /// </summary>
        /// <returns></returns>
        public override double Cost()
        {
            Console.WriteLine("Pearl is 7 yuan");
            // [Core]
            return base.Cost() + money;
        }
    }
}

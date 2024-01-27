using DecoratorPattern.Decorators.AbstactDecorators;

namespace DecoratorPattern.Decorators
{
    internal class PuddingBatching : BeverageDecorator
    {
        private static double money = 5;

        /// <summary>
        /// 配料返回本身价格的同时要加上父类已有的价格（父类的价格包括了在此之前累计的其他配料的价格）
        /// </summary>
        /// <returns></returns>
        public override double Cost()
        {
            Console.WriteLine("Pudding is 5 yuan");
            // [Core]
            return base.Cost() + money;
        }
    }
}

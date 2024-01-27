// See https://aka.ms/new-console-template for more information
using DecoratorPattern.Components;
using DecoratorPattern.Components.IBaseComponents;
using DecoratorPattern.Decorators;
using DecoratorPattern.Decorators.AbstactDecorators;

/// 装饰器模式：允许向一个现有的对象添加新的功能，同时又不改变其结构（在一个功能基础之上进行叠加）
/// 装饰器模式可用于设计付费服务，在基础付费的基础之上，根据新添加的功能去获取对应新的付费
/// 使用饮料付费业务场景来呈现装饰器模式
// Call:
// 示例，一份奶茶加2布丁加1仙草1珍珠
IBaseBeverage milkTea = new MilkTea();
BeverageDecorator pudding1 = new PuddingBatching();
BeverageDecorator pudding2 = new PuddingBatching();
BeverageDecorator herb = new HerbBatching();
BeverageDecorator pearl = new PearlBatching();

// 给奶茶加布丁
pudding1.AddBatching(milkTea);
// 加入第二份布丁
pudding2.AddBatching(pudding1);
// 加入仙草
herb.AddBatching(pudding2);
// 加入珍珠
pearl.AddBatching(herb);
// 计算总价格
Console.WriteLine(pearl.Cost());

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using ObservePattern.EventObjects;
using ObservePattern.Observers;

/// 观察者模式：定义了一种一对多的依赖关系，当一个对象的状态发生改变时，其所有依赖者都会收到通知并自动更新。
/// 委托事件就是一种观察着模式
#region 方案1：使用聚合List和方法的方式
Weather weather = new();
// 添加观察者
Child observeChild = new();
Farmer observeFarmer = new();
Worker observeWorker = new();
weather.AddOberve(observeChild);
weather.AddOberve(observeFarmer);
weather.AddOberve(observeWorker);
// 执行事件
weather.RainEvent();

weather.AddOberve(new Pedestrian());
weather.RemoveOberve(observeWorker);

// 执行事件
weather.RainEvent();
#endregion
Console.WriteLine( "========================================================================");
#region 方案2：使用Event的方式
weather.WeatherEvent += observeChild.Action;
weather.WeatherEvent += observeFarmer.Action;
weather.WeatherEvent += observeWorker.Action;
weather.RainEvent2();
#endregion
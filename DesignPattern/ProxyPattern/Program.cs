// See https://aka.ms/new-console-template for more information
using ProxyPattern.Cases;
using ProxyPattern.Proxies;
using ProxyPattern.Subjects;
using ProxyPattern.Subjects.ISubjects;

/// 代理模式：为其他对象提供一种代理，以控制对这个对象的访问
/// call
ISubject proxy = new SubjectProxy(new RealSubject1());
proxy.DoSomething1();
proxy.DoSomething2();
proxy.DoSomething3();

Console.WriteLine("===============================================");
#region Order Case
// 使用代理操作订单
IOrderSubject orderProxy = new OrderProxy(new RealOrderSubject("笔记本电脑",100, "张三"));
// 修改订单
orderProxy.SetProductName("新笔记本电脑","张三");// not authorization
Console.WriteLine(orderProxy.GetProjectName());
#endregion
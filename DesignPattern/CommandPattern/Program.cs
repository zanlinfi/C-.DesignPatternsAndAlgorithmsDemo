// See https://aka.ms/new-console-template for more information
// Call
// 1.定义命令调用者
using CommandPattern.Commands;
using CommandPattern.Invokers;
using CommandPattern.Receivers;

/// 命令模式：它将请求封装成一个对象，从而使不同的请求可以进行参数化，队列化或者记录日志，并且能够支持撤销操作
/// 目的： 命令模式的核心思想是将请求的发送者和接收者解耦，通过命令对象来实现二者之间的通信
/// 应用于数据的恢复，命令撤销等
/// 一个命令对应一个接收者，多个命令可以对应一个接收者，（一个命令也可以对应多个接收者（另外的写法））
/// 当有需要同时执行多个命令时可以利用命令队列对象帮助添加、移除和执行所有命令
// 1.定义命令调用者、执行命令、命令接收者(针对接收者1，可以执行命令1和命令2)
Invoker invoker = new Invoker(new ConcreteCommand2(new Receiver1()));
// 2.执行命令
invoker.InvokeCommand();

// (针对接收者2，可以执行命令3)
invoker = new Invoker(new ConcreteCommand3(new Receiver2()));
invoker.InvokeCommand();

Console.WriteLine( "=============================================================");
// 命令队列执行1、2、3命令
// 初始化命令
var cmd1 = new ConcreteCommand1(new Receiver1());
var cmd2 = new ConcreteCommand2(new Receiver1());
var cmd3 = new ConcreteCommand3(new Receiver2());
// 初始化命令队列
CommandQueue commandQueue = new();
commandQueue.AddCommand(cmd1);
commandQueue.AddCommand(cmd2);
commandQueue.AddCommand(cmd3);
QueueInvoker queueInvoker = new QueueInvoker(commandQueue);
queueInvoker.ExecuteCommands();

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
/*
 * 策略模式：定义一系列算法，将每个算法封装起来，可以在不修改前端代码的情况下进行相互的替换
 * 仓储模式就是一种策略模式（根据需要切换不同的仓储，比如EFCore仓储、Dapper仓储的切换）
 * 
 */

// Call
using StrategyPattern.Contexts;
using StrategyPattern.Strategies;

//StrategyContext context = new(new EFCoreRepository());  // 选择EFCore仓储
StrategyContext context = new(new DapperRepository());  // 选择Dapper仓储
context.Algorithm();
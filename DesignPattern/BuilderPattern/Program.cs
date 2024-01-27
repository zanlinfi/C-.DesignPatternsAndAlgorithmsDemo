// See https://aka.ms/new-console-template for more information
/*
 *建造者模式： 用于创建复杂对象，复杂的对象通常由各个部分的子对象的一定算法组成
 *建造者模式将对象的复杂对象的创建和使用分离（客户端无需知道复杂对象的中的具体部分的全部内容去自己创建，而是直接调用）
 */
using BuilderPattern.Builders;
using BuilderPattern.Directors;
using BuilderPattern.Products;

ComputerDirector director = new();
HWComputerBuilder hwBuilder = new();
director.BuildComputer(hwBuilder);
Computer hw = hwBuilder.GetComputer();
hw.ShowComputer();
Console.WriteLine("===================================");
HPComputerBuilder hpBuilder = new();
director.BuildComputer(hpBuilder);
Computer hp = hpBuilder.GetComputer();
hp.ShowComputer();
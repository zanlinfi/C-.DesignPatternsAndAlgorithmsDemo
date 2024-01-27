// See https://aka.ms/new-console-template for more information
/*
 * 模板方法模式：它定义了一个算法的骨架，将一些步骤的具体实现延迟到子类中。模板方法模式使得子类可以在不改变算法结构的情况下重新定义算法的某些步骤。
 * 目的：将算法中必要的部分让子类去自定义
 * 核心是钩子函数99
 */
// Call:
using TemplateMethodPattern;

TemplateBase templateBase = new ConcreteBusiness2();  // 业务1的操作流程
templateBase.GetResult();
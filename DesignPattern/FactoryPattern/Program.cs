// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
/// 工厂模式创建对象：定义一个用于创建对象的接口，让子类决定实例化哪一个类。工厂方法模式使得一个类的实例化延迟到子类之中
using FactoryPattern.Factories;
using FactoryPattern.Factories.Factory;
using FactoryPattern.Interfaces;

///工厂方法模式：将对象的创建与使用解耦，隐藏了对象的创建细节，符合开闭原则，提高了系统的灵活性和可维护性（当有新的产品添加时，不需要修改原来的）
///工厂方法模式解决了简单工厂模式创建对象时，细节与抽象依赖的问题，将创建建对象时抽象对细节的依赖，转换为了细节对抽象的依赖
#region Main Section
// 2.根据对应的工厂调用创建对象方法来获取对象
ICalculator calculator = GetCalculatorFactory("*").GetCalculator();
// 3.获取具体对象后传入参数得到对应值
Console.WriteLine(calculator.Calculate(10, 11));

/// 1.采用反射来取代switch创建对象[Attribute]: 通过Attribute将操作符附加在具体工厂对象上来获取[Option 2 Commend]
// 1.1.使用Attribute创建特性类，给类贴上Attribute对应的数据：创建OperAttribute class
// 1.2.在程序运行后拿到Attribute和类的描述关系病返回对应的工厂对象：创建反射类获取对应关系
// 1.3.调用反射实现下的工厂模式获取对象
ReflectionToFactory factory = new();
ICalculatorFactory calcFactory = factory.GetFactory("+");
ICalculator calculatorAdd = calcFactory.GetCalculator();
double resAdd = calculatorAdd.Calculate(10, 11);
Console.WriteLine(resAdd); 
#endregion

#region Methods Section
/// 1.根据操作符来获取对应的工厂（运算符和工厂对象的对应关系）[Option 1 not commend]
static ICalculatorFactory GetCalculatorFactory(string oper) => oper switch
{
    "+" => new AddCalculatorFactory(),
    "-" => new SubstractCalculatorFactory(),
    "*" => new MultipleCalculatorFactory(),
    "/" => new DivideCalculatorFactory(),
    _ => throw new NotImplementedException()
};

#endregion



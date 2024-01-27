// See https://aka.ms/new-console-template for more information
using AbstractFactoryPattern.AbstractFactoryToComputer.Factories;
using AbstractFactoryPattern.AbstractFactoryToComputer.Interfaces;
using AbstractFactoryPattern.AbstractFactoryToComputer.Reflections;
using AbstractFactoryPattern.AbstractFactoryToDatabase.Entities;
using AbstractFactoryPattern.AbstractFactoryToDatabase.Factories.IFactories;
using AbstractFactoryPattern.AbstractFactoryToDatabase.Reflections;
/// 抽象工厂模式：在工厂模式的基础之上实现了产品族的一致性：抽象工厂方法模式中的具体工厂类负责创建一系列相关的产品，保证了这些产品之间的一致性，即它们属于同一个产品族（同品牌分组）
/// 抽象工厂模式解决工厂模式添加新产品种类时，会造成工厂对象无限衍生的问题，缩减了创建子类工厂的数量；将产品分组（根据品牌分组，每组中有不同的产品），一个工厂对象对应一组的产品对象创建
/// 减少了工厂类的创建,降低了冗余代码的创建 

#region Case1: 创建不同品牌的对象（Dell、HP）的键盘、鼠标、主机
// call 抽象工厂：根据类型（鼠标、键盘，品牌）创建对应对象
ReflectionToAbstractFactory reflectionToAbstractFactory = new();
IAbstractFactory abstractFactory = reflectionToAbstractFactory.GetFactory("Dell");
IKeyboard dellKeyboard = abstractFactory.GetKeyboard();
IMouse dellMouse = abstractFactory.GetMouse();
dellKeyboard.ShowKeyboardBrand();
dellMouse.ShowMouseBrand();
#endregion

#region Case2: 使用抽象工厂模式实现数据库的更换
// call 抽象工厂：SqlServer、MySql、SqlLite
DatabaseSelectReflection databaseSelect = new();
IDatabaseFactory databaseFactroy = databaseSelect.GetFactory("Sqlserver");  // MySql, SqlLite
databaseFactroy.GetDatabaseDepartment().GetDepartment(1);
databaseFactroy.GetDatabaseDepartment().InsertDepartment(new Department {ID=2,Name="testName"});
databaseFactroy.GetDatabaseUser().GetUser(1);
databaseFactroy.GetDatabaseUser().InsertUser(new User {ID=2,Name="testName" });

#endregion
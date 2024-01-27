// See https://aka.ms/new-console-template for more information
/// 它允许多个对象都有机会处理请求，从而避免请求的发送者和接收者之间的耦合关系
/// 降低了请求发送者和接收者之间的耦合关系，增强了系统的灵活性
using ChainOfResponsibilityPattern;

// 配置职责链
AbsProcesshandler worker = new Worker();
AbsProcesshandler mentor = new Menter();
AbsProcesshandler domainLeader = new DomainLeader();
AbsProcesshandler manager = new Manager();
worker.Successor = mentor;
mentor.Successor = domainLeader;
domainLeader.Successor = manager;
worker.Process();



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Cases
{
    internal class OrderProxy(RealOrderSubject subject) : IOrderSubject
    {
        // 封装实体对象的引用
        private readonly RealOrderSubject _subject = subject;
        public string GetOrderUser()
        {
            // 查看不做权限控制
           return _subject.GetOrderUser();
        }

        public int GetProductCount()
        {
            // 查看不做权限控制
            return _subject.GetProductCount();
        }

        public string GetProjectName()
        {
            // 查看不做权限控制
            return _subject.GetProjectName();
        }

        public void SetOrderUser(string orderUser, string userName)
        {
            // 权限控制
            if (orderUser is not null && userName == _subject.OrderUser)
            {
                _subject.OrderUser = orderUser;
            }
            else
            {
                Console.WriteLine("没有权限修改此数据！");
            }
        }

        public void SetProductCount(int productCount, string userName)
        {
            // 权限控制
            if ( userName == _subject.OrderUser)
            {
                _subject.ProductCount = productCount;
            }
            else
            {
                Console.WriteLine("没有权限修改此数据！");
            }
        }

        public void SetProductName(string productName, string userName)
        {
            // 权限控制
            if (productName is not null && userName == _subject.OrderUser)
            {
                _subject.ProductName = productName;
            }
            else
            {
                Console.WriteLine("没有权限修改此数据！");
            }
        }
    }
}

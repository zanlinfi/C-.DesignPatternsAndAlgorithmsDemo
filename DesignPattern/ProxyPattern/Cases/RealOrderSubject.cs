using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Cases
{
    /// <summary>
    /// 实际订单对象，订单对象只负责处理订单操作，而不会对访问做任何处理，针对访问的处理交由代理对象处理
    /// </summary>
    internal class RealOrderSubject : IOrderSubject
    {
        public string ProductName { get; set; }
        public int ProductCount { get; set; }

        public string OrderUser { get; set; }

        public RealOrderSubject(string productName, int productCount, string orderUser)
        {
            this.ProductName = productName;
            this.ProductCount = productCount;
            this.OrderUser = orderUser;
        }

        public string GetOrderUser()
        {
            return this.OrderUser;
        }

        public int GetProductCount()
        {
           return this.ProductCount;
        }

        public string GetProjectName()
        {
            return this.ProductName;
        }

        public void SetOrderUser(string orderUser, string userName)
        {
            this.OrderUser= orderUser;
        }

        public void SetProductCount(int productCount, string userName)
        {
            this.ProductCount= productCount;
        }

        public void SetProductName(string productName, string userName)
        {
            this.ProductName = productName;
        }
    }
}

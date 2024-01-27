using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Cases
{
    /// <summary>
    /// 实体对象和代理对象的通用接口
    /// </summary>
    internal interface IOrderSubject
    {
        string GetProjectName();

        void SetProductName(string productName, string userName);

        int GetProductCount();

        void SetProductCount(int productCount, string userName);

        string GetOrderUser();

        void SetOrderUser(string orderUser, string userName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDemo.Service.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool Login(string username, string password);
    }
}

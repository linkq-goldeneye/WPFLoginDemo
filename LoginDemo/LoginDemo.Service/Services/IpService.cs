using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LoginDemo.Service.Interfaces;

namespace LoginDemo.Service.Services
{
    public class IpService : IIpService
    {
        public string IpAddressGet()
        {
            try
            {
                string localIP = string.Empty;
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    localIP = endPoint.Address.ToString();
                }




                var t1_html = HttpGetPageHtml("http://www.ip111.cn/", "utf-8");
                var t2_html = HttpGetPageHtml("http://www.882667.com/", "utf-8");

                var t1_ip = GetIPFromHtml(t1_html); // 
                var t2_ip = GetIPFromHtml(t2_html);

                return t1_ip;
            }
            catch
            { return string.Empty; }
        }



        public static string HttpGetPageHtml(string url, string encoding)
        {
            string pageHtml = string.Empty;
            try
            {
                using (WebClient MyWebClient = new WebClient())
                {
                    Encoding encode = Encoding.GetEncoding(encoding);
                    MyWebClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.84 Safari/537.36");
                    MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                    byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据
                    pageHtml = encode.GetString(pageData);
                }
            }
            catch (Exception e)
            {

            }
            return pageHtml;
        }
        /// <summary>
        /// 从html中通过正则找到ip信息(只支持ipv4地址)
        /// </summary>
        /// <param name="pageHtml"></param>
        /// <returns></returns>
        public static string GetIPFromHtml(string pageHtml)
        {
            //验证ipv4地址
            string reg = @"(?:(?:(25[0-5])|(2[0-4]\d)|((1\d{2})|([1-9]?\d)))\.){3}(?:(25[0-5])|(2[0-4]\d)|((1\d{2})|([1-9]?\d)))";
            string ip = "";
            Match m = Regex.Match(pageHtml, reg);
            if (m.Success)
            {
                ip = m.Value;
            }
            return ip;
        }
    }


}

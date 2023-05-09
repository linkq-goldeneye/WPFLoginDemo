using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LoginDemo.Service.Interfaces;

namespace LoginDemo.Service.Services
{
    public class LoginService : ILoginService
    {

        public LoginService()
        {

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            return Requst(username, password);
        }

        private bool Requst(string username, string password)
        {

            string url = "http://47.93.186.205:8020/api/Login/getToken.do?username={0}&password={1}";
            url = string.Format(url, username, password);

            var client = new RestClient(url);
            var request = new RestRequest("", Method.Get);

            request.Timeout = 10000;
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Connection", "keep-alive");


            RestResponse response = client.Execute(request);

            JObject responseContent = (JObject)JsonConvert.DeserializeObject(response.Content);

            if (string.IsNullOrEmpty(responseContent["access_token"].ToString()))
                return false;
            else
                return true;
        }
    }
}

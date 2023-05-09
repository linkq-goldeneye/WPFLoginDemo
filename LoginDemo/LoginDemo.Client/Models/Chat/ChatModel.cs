using System.Collections.Generic;
using Prism.Mvvm;

namespace LoginDemo.Client.Models.Chat
{
    public class ChatModel : BindableBase
    {
    }

    public class DialogOrders
    {
        public string Image { get; set; }
        public string Content { get; set; }

        private string UserAvastar = "/LoginDemo.Assets;component/Images/userlarge.png";
        public string AiAvastar = "/LoginDemo.Assets;component/Images/LinkQ.ico";

        public DialogOrders(string content, bool IsUser)
        {
            Content = content;
            if (IsUser)
            {
                Image = UserAvastar;
            }
            else
            {
                Image = AiAvastar;
            }

        }
    }

    public class ContentOwner
    {
        public string User { get; set; }
        public string Ai { get; set; }
        public ContentOwner()
        {
            Ai = "AI";
            User = "Human";
        }
    }


    public class requstBodyClass
    {
        public string IpAddress { get; set; }
        public string[] promptHistory { get; set; }
        public requstBodyClass(List<string> PromptHistory, string ipAddress)
        {
            promptHistory = new string[PromptHistory.Count];
            for (int i = 0; i < PromptHistory.Count; i++)
                promptHistory[i] = PromptHistory[i];
            IpAddress = ipAddress;
        }

        public requstBodyClass(List<string> PromptHistory)
        {
            promptHistory = new string[PromptHistory.Count];
            for (int i = 0; i < PromptHistory.Count; i++)
                promptHistory[i] = PromptHistory[i];
        }
    }

}

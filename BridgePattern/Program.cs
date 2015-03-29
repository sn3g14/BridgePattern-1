using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {

            SendData sendEmail = new SendEmail();
            sendEmail.BridgeComponents = new NotificationService();
            sendEmail.Send();


            sendEmail.BridgeComponents = new ThirdPartyNotificationApi();
            sendEmail.Send();
        }
    }


    public interface INotificationBridge
    {
        bool Send(string messageType);
    }

    public abstract class SendData
    {
        public INotificationBridge BridgeComponents;

        public abstract bool Send();
    }

    public class SendEmail:SendData
    {

        public override bool Send()
        {
            return BridgeComponents.Send("Email");
        }
    }

    public class SendMessage : SendData
    {
        public override bool Send()
        {
            return BridgeComponents.Send("Message");
        }
    }

    public class NotificationService : INotificationBridge
    {
        public bool Send(string messageType)
        {
            Console.WriteLine("Sending"+messageType+"using WebSerivce");
            return true;
        }
    }

    public class ThirdPartyNotificationApi:INotificationBridge
    {

        public bool Send(string messageType)
        {
            Console.WriteLine("Sending" + messageType + "using ThirdPartyApi");
            return true;
        }
    }
}

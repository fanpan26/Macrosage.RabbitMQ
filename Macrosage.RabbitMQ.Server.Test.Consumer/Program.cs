using Macrosage.RabbitMQ.Server.Customer;
using Pz.Weixin.Utils.Common.Http;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Macrosage.RabbitMQ.Server.Test.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2,3,4,5};
            Console.WriteLine("111=================" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "=====================111");

            ReceiveMessage("");
            Console.ReadKey();
        }

        static void ReceiveMessage(string threadName)
        {
            IMessageCustomer customer = new MessageCustomer();
            string queueName = "Macrosage.Queue.Test1";

            customer.ComsumeMulityThread(queueName, (message, cosumeCount, messageCount) =>
              {
                  string result = RequestUtility.HttpGet("http://imfyp.com/api/account.ashx?op=category&token=123123");
                  Console.WriteLine("=================" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "=====================");
                  return true;
              });

          
        }
    }
}

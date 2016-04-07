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

            //Parallel.For(0, 3, i =>
            //{
            //    ReceiveMessageMulityThread();
            //});
            ReceiveMessage("test1");
            ReceiveMessage("test2");
            ReceiveMessage("test3");

            Console.ReadKey();
        }

        static void ReceiveMessage(string queueName)
        {
            var customer = RabbitMQFactory.Instance.CreateCustomer(queueName);
            //开始监听
            customer.StartListening();
            //定义接收消息回调函数
            customer.ReceiveMessageCallback = (message =>
            {
               // string result = RequestUtility.HttpGet("http://imfyp.com/api/account.ashx?op=category&token=123123");
                Console.WriteLine($"{queueName}接收到消息{message}");
                return true;
            });
        }

        static void ReceiveMessageMulityThread()
        {
           var customer = new MessageCustomer("Macrosage.Queue.Test1");
            //开始监听
            customer.StartListening();
            //定义接收消息回调函数
            customer.ReceiveMessageCallback = (message =>
            {
                string result = RequestUtility.HttpGet("http://imfyp.com/api/account.ashx?op=category&token=123123");
                Console.WriteLine($"接收到消息{message}");
                return true;
            });
        }
    }
}

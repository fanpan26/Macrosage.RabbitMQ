using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RabbitMQ.Server.Customer
{
    public interface IMessageCustomer
    {
        /// <summary>
        /// 消费消息
        /// </summary>
        /// <param name="queueName"></param>
        void Consume(string queueName, Func<string,long ,long,bool> fun);
        void ComsumeSingleThread(string queueName, Func<string, long, long, bool> fun);
        void ComsumeMulityThread(string queueName, Func<string, long, long, bool> fun);
    }
}

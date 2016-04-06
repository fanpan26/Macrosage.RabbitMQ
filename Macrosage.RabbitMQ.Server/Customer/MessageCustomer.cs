using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RabbitMQ.Server.Customer
{
    public class MessageCustomer : IMessageCustomer
    {
        /// <summary>
        /// 消息处理成功之后调用
        /// </summary>
        /// <param name="model"></param>
        /// <param name="args"></param>
        public void BasicAck(IModel model, BasicDeliverEventArgs args)
        {
             model.BasicAck(args.DeliveryTag, false);
        }

        /// <summary>
        /// 消费信息
        /// </summary>
        /// <param name="queueName"></param>
        public void Consume(string queueName,Func<string,long,long,bool> fun)
        {
            var factory = RabbitMQFactory.Instance.CreateFactory();

            using (var connection = factory.CreateConnection())
            {
                using (var model = connection.CreateModel())
                {
                    bool durable = true;
                    bool autoDeleteMessage = false;
                    var queue = model.QueueDeclare(queueName, durable, false, false, null);
                   
                    //公平分发,不要同一时间给一个工作者发送多于一个消息
                    model.BasicQos(0, 1, false);

                    var consumer = new QueueingBasicConsumer(model);
                   
                    model.BasicConsume(queueName, autoDeleteMessage, consumer);

                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        bool result = fun(message, queue.ConsumerCount, queue.MessageCount);
                        if (result)
                        {
                            BasicAck(model, ea);
                        }

                    }

                }
            }
        }


        public void ComsumeSingleThread(string queueName, Func<string, long, long, bool> fun)
        {
            Consume(queueName, fun);
        }

        public void ComsumeMulityThread(string queueName, Func<string, long, long, bool> fun)
        {
            List<int> list = new List<int>() { 1, 2, 3 };//开三个线程
            Parallel.ForEach(list, item =>
            {
                Consume(queueName, fun);
            });
        }
    }
}

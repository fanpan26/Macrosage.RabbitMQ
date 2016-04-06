using Macrosage.RabbitMQ.Server.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RabbitMQ.Server.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageProduct product = new MessageProduct();
            string queueName = "Macrosage.Queue.Test1";

            for (int i = 0; i < 500; i++)
            {
                //var msg = "{\"result\":0,\"code\":\"ok\",\"msg\":null,\"data\":[{\"id\":1,\"parentid\":0,\"name\":\"衣\"},{\"id\":2,\"parentid\":0,\"name\":\"食\"},{\"id\":3,\"parentid\":0,\"name\":\"住\"},{\"id\":4,\"parentid\":0,\"name\":\"行\"},{\"id\":5,\"parentid\":0,\"name\":\"娱乐\"},{\"id\":6,\"parentid\":1,\"name\":\"上衣\"},{\"id\":7,\"parentid\":1,\"name\":\"裤子\"},{\"id\":8,\"parentid\":1,\"name\":\"T恤\"},{\"id\":9,\"parentid\":1,\"name\":\"鞋\"},{\"id\":10,\"parentid\":1,\"name\":\"内衣\"},{\"id\":11,\"parentid\":2,\"name\":\"早饭\"},{\"id\":12,\"parentid\":2,\"name\":\"午饭\"},{\"id\":13,\"parentid\":2,\"name\":\"晚饭\"},{\"id\":14,\"parentid\":2,\"name\":\"零食\"},{\"id\":15,\"parentid\":2,\"name\":\"聚餐\"},{\"id\":16,\"parentid\":3,\"name\":\"房租\"},{\"id\":17,\"parentid\":3,\"name\":\"水电\"},{\"id\":18,\"parentid\":3,\"name\":\"网费\"},{\"id\":19,\"parentid\":3,\"name\":\"生活用品\"},{\"id\":20,\"parentid\":4,\"name\":\"公交卡\"},{\"id\":21,\"parentid\":4,\"name\":\"火车票\"},{\"id\":22,\"parentid\":4,\"name\":\"飞机票\"},{\"id\":23,\"parentid\":4,\"name\":\"出租车\"},{\"id\":24,\"parentid\":5,\"name\":\"KTV\"},{\"id\":25,\"parentid\":5,\"name\":\"健身\"},{\"id\":26,\"parentid\":5,\"name\":\"游乐场\"},{\"id\":27,\"parentid\":5,\"name\":\"其他\"}]}";
                var msg = "test"+i;
                product.Publish(msg, queueName);
                Console.WriteLine("消息已经发送出"+i);
            }

        }
    }
}

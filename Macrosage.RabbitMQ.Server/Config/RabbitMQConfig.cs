using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RabbitMQ.Server.Config
{
    public sealed class RabbitMQConfig
    {
        /// <summary>
        /// 全局队列
        /// </summary>
        public const string PUBLISH_GLOBAL_QUEUE = "PUBLISH_GLOBAL_QUEUE";

        /// <summary>
        /// 是否持久化
        /// </summary>
        public static bool IsDurable
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// 线程个数
        /// </summary>
        public static int ThreadCount
        {
            get
            {
                return 3;
            }
        }
    }
}

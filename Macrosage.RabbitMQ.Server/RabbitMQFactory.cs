using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RabbitMQ.Server
{
    public class RabbitMQFactory
    {
        #region 单例
        private RabbitMQFactory() { }
        private static RabbitMQFactory _instance;

        private static object _lock = new object();
        public static RabbitMQFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new RabbitMQFactory();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region 私有变量
        //rabbitMQ 服务地址
        private string _hostName
        {
            get
            {
                return "localhost";
            }
        }
        // 用户名
        private string _userName
        {
            get
            {
                return "panzi";
            }
        }
        //密码
        private string _passWord
        {
            get
            {
                return "panzi123";
            }
        }
        
        private ConnectionFactory _factory { get; set; }
        #endregion

        #region 创建工厂
        public ConnectionFactory CreateFactory()
        {
            if (_factory == null) {

                ExceptionHandler.ThrowArgumentNull("_hostName", _hostName);
                ExceptionHandler.ThrowArgumentNull("_userName", _userName);
                ExceptionHandler.ThrowArgumentNull("_passWord", _passWord);

                _factory = new ConnectionFactory();
                _factory.HostName = _hostName;
                _factory.UserName = _userName;
                _factory.Password = _passWord;
            }
            return _factory;
        }
        #endregion
    }
}

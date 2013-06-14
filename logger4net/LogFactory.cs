/********************************************************
 * Encapsulation of log4net for programer
 * Written by Alex Yu (yubhbh@gmail.com)
 * 
 * Released to the public domain, use at your own risk!
 ********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.IO;

namespace logger4net
{
    public class LogFactory
    {
        public static Dictionary<string,ILog> loggerlist = new Dictionary<string,ILog>();
        public static object lockobj = new object();
        public static ILog create(string logger)
        {
            if (!LogHelper.Islog4netInit)
            {
                throw new SystemException("Log4net配置未初始化！请先在Main方法中，或Gloabal.cs 中调用LogHelper.InitLog4Net()方法！ ");
            }

            var lgname = logger.ToString();
            if (loggerlist.ContainsKey(lgname))
            {
                return loggerlist[lgname];
            }

            ILog log = LogManager.GetLogger(lgname);//获取一个日志记录器
            if (!loggerlist.ContainsKey(lgname))
            {
                lock (lockobj)
                {
                    if(!loggerlist.ContainsKey(lgname)){
                      loggerlist.Add(lgname, log);
                    }
                }
             
              
            }
            return log;
        }
    }

    public class Logger
    {
        public string logger { get; set; }
        public string msg { get; set; }
        public Exception ex { get; set; }

        public string ToString()
        {
            //if (this.ex == null)
            //{
            //    return "Msg:" + this.msg;
            //}
            return  this.msg;
        }


        //初始化log4Net配置
        public static bool InitLog4Net(string configfullPath)
        {
           return LogHelper.InitLog4Net(configfullPath);
        }

        public static Logger Create(string logger,string msg,Exception ex)
        {
            return new Logger() { logger = logger, msg = msg, ex = ex };
        }

        public static Logger Create(string logger, string msg)
        {
            return new Logger() { logger = logger, msg = msg };
        }


        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="log"></param>
        public static void Info(string logger, string msg)
        {
            LogHelper.Info(Logger.Create(logger, msg));
        }

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="log"></param>
        public static void Info(string logger, string msg, Exception ex)
        {
            LogHelper.Info(Logger.Create(logger, msg, ex));
        }

        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="log"></param>
        public static void Debug(string logger, string msg)
        {
            LogHelper.Debug(Logger.Create(logger,msg));
        }

        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="log"></param>
        public static void Debug(string logger, string msg, Exception ex)
        {
            LogHelper.Debug(Logger.Create(logger, msg, ex));
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="log"></param>
        public static void Warn(string logger, string msg)
        {
            LogHelper.Warn(Logger.Create(logger, msg));
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="log"></param>
        public static void Warn(string logger, string msg, Exception ex)
        {
            LogHelper.Warn(Logger.Create(logger, msg, ex));
        }



        /// <summary>
        /// 错误（一般用在catch里面）
        /// </summary>
        /// <param name="log"></param>
        public static void Error(string logger, string msg)
        {
            LogHelper.Error(Logger.Create(logger, msg));
        }

        /// <summary>
        /// 错误（一般用在catch里面）
        /// </summary>
        /// <param name="log"></param>
        public static void Error(string logger, string msg,Exception ex)
        {
            LogHelper.Error(Logger.Create(logger, msg,ex));
        }


        /// <summary>
        /// 致命错误，严重异常
        /// </summary>
        /// <param name="log"></param>
        public static void Fatal(string logger, string msg)
        {
            LogHelper.Fatal(Logger.Create(logger, msg));
        }

        /// <summary>
        /// 致命错误，严重异常
        /// </summary>
        /// <param name="log"></param>
        public static void Fatal(string logger, string msg, Exception ex)
        {
            LogHelper.Fatal(Logger.Create(logger, msg, ex));
        }
    }

    public class LogHelper
    {
        public static bool Islog4netInit = false;
        public static bool InitLog4Net(string configfullPath){
            
            if (!File.Exists(configfullPath))
            {
                throw new FileNotFoundException("请传入Log4Net.config的正确路径!如：AppDomain.CurrentDomain.BaseDirectory + \"log4net/Log4Net.config\"");
            }
            var file = new FileInfo(configfullPath);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(file);
            //log4net.Config.XmlConfigurator.Configure(); 使用 App.config
            Islog4netInit = true;
            return Islog4netInit;
        }

        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="log"></param>
        public static void Debug(Logger entity)
        {
            ILog log = LogFactory.create(entity.logger);
            if(entity.ex!=null){
                log.Debug(entity.ToString(), entity.ex);//写入一条新log
            }
            else{
                log.Debug(entity.ToString());
            }
         
        }

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="log"></param>
        public static void Info(Logger entity)
        {
            ILog log = LogFactory.create(entity.logger);
            if (entity.ex != null)
            {
                log.Info(entity.ToString(), entity.ex);//写入一条新log
            }
            else
            {
                log.Info(entity.ToString());
            }
           
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="log"></param>
        public static void Warn(Logger entity)
        {
            ILog log = LogFactory.create(entity.logger);
            if (entity.ex != null)
            {
                log.Warn(entity.ToString(), entity.ex);//写入一条新log
            }
            else
            {
                log.Warn(entity.ToString());
            }
        }

        /// <summary>
        /// 错误（一般用在catch里面）
        /// </summary>
        /// <param name="log"></param>
        public static void Error(Logger entity)
        {
            ILog log = LogFactory.create(entity.logger);
          
            if (entity.ex != null)
            {
                log.Error(entity.ToString(), entity.ex);//写入一条新log
            }
            else
            {
                log.Error(entity.ToString());
            }
        }

        /// <summary>
        /// 致命错误，严重异常
        /// </summary>
        /// <param name="log"></param>
        public static void Fatal(Logger entity)
        {
            ILog log = LogFactory.create(entity.logger);
            
            if (entity.ex != null)
            {
                log.Fatal(entity.ToString(), entity.ex);//写入一条新log
            }
            else
            {
                log.Fatal(entity.ToString());
            }
        }

    }


    
}

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
using System.IO;
using System.Threading;
using logger4net;

namespace Test.Log.Client
{
    class Program
    {


        static void Main(string[] args)
        {

            Logger.InitLog4Net(AppDomain.CurrentDomain.BaseDirectory + "log4net/Log4Net.config");

            for (var i = 0; i < 10; i++)
            {
                Console.Write("i->" + i + "\n");
                Thread th = new Thread(() =>
                {
                    test();
                    //for (var j =0; j < 1000; j++)
                    //{
                    //    Console.Write("j->" + j + "\n");
                       
                    //}
                });
                th.Start();

           
            }


            Console.ReadLine();
        }

        /// <summary>
        /// 测试实例
        /// </summary>
        public static void test()
        {


            Logger.Info(LoggerName.Hotel, "my info testmsg ");

            Logger.Debug(LoggerName.Hotel, "my debug testmsg ");

            Logger.Debug(LoggerName.Hotel, "my debug testmsg ", new Exception("here is debug exception"));

            Logger.Error(LoggerName.Hotel, "my test msg ");

            Logger.Error(LoggerName.Hotel, "my test msg ", new Exception("alex excetiopn coming"));

            Logger.Warn(LoggerName.Hotel, "my Warn testmsg ", new FieldAccessException("can't find your file!"));

            Logger.Fatal(LoggerName.Hotel, "er-OH! NO! Fatal ! ");

            Logger.Fatal(LoggerName.Hotel, "er-OH! NO! Fatal ! ", new ApplicationException("Fatal!"));

    
        }   


    }


}

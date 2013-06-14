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
using System.Xml.Linq;
using System.Collections;



namespace Log4NetConfigTool
{
    public class ConfigHandler
    {
        public string[] traceAppenders = { "INFO", "DEBUG", "WARN", "ERROR", "FATAL", "AdoNetAppender_sqlserver" };
        public string configFilePath = "";
        public string loggerFilePath = "";
        public static string configFileName = "Log4Net.config";
        public static string loggerFileName = "Logger.cs";


        public ConfigHandler(string configPath,string loggercodeFilePath)
        {
            if (!File.Exists(configPath + "/" + configFileName))
            {
                throw new FileNotFoundException("请先添加文件Log4Net.config添加到项目中log4net下!");
            }
            if (!File.Exists(loggercodeFilePath + "/" + loggerFileName))
            {
                throw new FileNotFoundException("请先添加文件Logger.cs添加到项目中log4net下!");
            }

            configFilePath = configPath + "/" + configFileName;
            loggerFilePath = loggercodeFilePath + "/" + loggerFileName;
        }

        public static string CheckConfig(string configPath, string loggercodeFilePath)
        {
            var msg = string.Empty; 
            if (!File.Exists(configPath + "/" + configFileName))
            {
                msg = "请先添加文件Log4Net.config添加到目录：" + configPath + "\\" + configFileName;
            }

            if (!File.Exists(loggercodeFilePath + "/" + loggerFileName))
            {
                msg +="|" +  "请先添加文件Logger.cs添加到目录：" + loggercodeFilePath + "\\" + loggerFileName;
            }

            if (msg == string.Empty) msg = "success";
            return msg;
        }

        public List<LoggerEntity> GetLoggerList()
        {
            List<LoggerEntity> list = new List<LoggerEntity>();
            XDocument doc = XDocument.Load(configFilePath);
            var loggers = doc.Descendants("logger").ToList();
            if (loggers != null)
            {
                foreach (var logger in loggers)
                {
                    LoggerEntity l = new LoggerEntity();
                    l.loggerName = logger.Attribute("name").Value;

                    var appenders = logger.Elements("appender-ref").ToList();
                    if (appenders != null)
                    {
                        foreach (var appender in appenders)
                        {
                            for (var i = 0; i < traceAppenders.Length; i++)
                            {
                                if (appender.Attribute("ref").Value.Contains(traceAppenders[i]))
                                {
                                    l.traceList[traceAppenders[i]] = true;
                                    continue;
                                }
                            }
                        }
                    }

                    list.Add(l);
                    

                }
            }

            return list;


        }

        public bool IsExistLogger(string loggerName)
        {
            XDocument doc = XDocument.Load(configFilePath);
            var loggers = doc.Descendants("logger").ToList();
            if (loggers != null)
            {
                foreach (var lg in loggers)
                {
                    if (lg.Attribute("name").Value == loggerName)
                        return true;
                }
            }
            return false;
        }

 
        public XElement MakeLoggerElement(LoggerEntity logger)
        {
            XElement newlogger = new XElement("logger",new XAttribute("name",logger.loggerName));
            foreach(var ap in logger.traceList){
               if(ap.Value == true){
                   //数据库目前只用一个appender
                   if(ap.Key=="AdoNetAppender_sqlserver"){
                       newlogger.Add(new XElement("appender-ref",new XAttribute("ref","AdoNetAppender_sqlserver")));
                       continue;
                   }

                   //每个appender 以名字加key结尾
                   newlogger.Add(new XElement("appender-ref",new XAttribute("ref",logger.loggerName+"_"+ ap.Key)));
               }
            }
            return newlogger;
        }

        public List<XElement> MakeAppnderElements(LoggerEntity logger)
        {
            List<XElement> ppnderElements = new List<XElement>();
            foreach (var ap in logger.traceList)
            {
                if (ap.Value == true)
                {
                    //数据库目前只用一个appender,不用创建了
                    if (ap.Key == "AdoNetAppender_sqlserver")
                    {
                        continue;
                    }

                    var savePath =  logger.loggerName + "\\" + ap.Key + "_";
                    if(logger.saveDir!=string.Empty){
                        savePath = logger.saveDir + "\\" + savePath;
                    }

                    //每个appender 以名字加key结尾
                    XElement apenderElement = new XElement("appender", new XAttribute("name", logger.loggerName + "_" + ap.Key),
                                                                      new XAttribute("type", "log4net.Appender.RollingFileAppender"),
                                                                      new XElement("param", new XAttribute("name", "File"), new XAttribute("value",savePath)),
                                                                      new XElement("param", new XAttribute("name", "AppendToFile"), new XAttribute("value", "true")),
                                                                      new XElement("param", new XAttribute("name", "DatePattern"), new XAttribute("value", "yyyy-MM-dd\".log\"")),
                                                                      new XElement("param", new XAttribute("name", "RollingStyle"), new XAttribute("value", "Date")),
                                                                      new XElement("param", new XAttribute("name", "StaticLogFileName"), new XAttribute("value", "false")),
                                                                      new XElement("layout", new XAttribute("type", "log4net.Layout.PatternLayout"),
                                                                                           new XElement("param", new XAttribute("name", "ConversionPattern"), new XAttribute("value", "%d [%t] %-5p %x %m %n"))
                                                                                   ),
                                                                      new XElement("filter", new XAttribute("type", "log4net.Filter.LevelRangeFilter"),
                                                                                            new XElement("param", new XAttribute("name", "LevelMin"), new XAttribute("value", ap.Key)),
                                                                                            new XElement("param", new XAttribute("name", "LevelMax"), new XAttribute("value", ap.Key))
                                                                                   ));

                    ppnderElements.Add(apenderElement);
               
                }
            }
            return ppnderElements;
        }


        public bool AddLogger(LoggerEntity logger)
        {
            if (logger.loggerName == "")
            {
                throw new Exception(logger.loggerName + ":logger 名称不充许为空!");
            }

            if (logger.isAllTraceSetFalse())
            {
                throw new Exception(logger.loggerName + "至少选择一个Appnder!!!");
            }

            if(IsExistLogger(logger.loggerName)){
                throw new  Exception(logger.loggerName + ":此logger 已经存在");
            }

            try{
                XDocument doc = XDocument.Load(configFilePath);
                XElement newLogger = MakeLoggerElement(logger);

                if (doc.Descendants("logger").ToList().Count == 0)
                {
                    doc.Descendants("root").Last().AddAfterSelf(newLogger);
                }
                else
                {
                    doc.Descendants("logger").Last().AddAfterSelf(newLogger);
                }

              

                List<XElement> appenders = MakeAppnderElements(logger);
                foreach (var ap in appenders)
                {
                    doc.Descendants("appender").Last().AddBeforeSelf(ap);
                }


                //sql数据库字符串
                if (logger.traceList["AdoNetAppender_sqlserver"] && logger.sqlConnstring != string.Empty)
                {
                    var aps = doc.Descendants("appender").ToList();
                    if(aps!=null){
                        foreach(var ap in aps){
                            if (ap.Attribute("name").Value == "AdoNetAppender_sqlserver")
                            {
                                ap.Descendants("connectionString").ToList()[0].Attribute("value").Value =logger.sqlConnstring;
                            }

                        }
                    }
                }

                //保存配置文件
                doc.Save(configFilePath);

                //重新logger.cs
                ResetLoggerFile();

            }
            catch(Exception e){
                throw e;
            }

            return true;
        }

        public bool RemoveLogger(string loggerName)
        {
            try
            {
                XDocument doc = XDocument.Load(configFilePath);
                var loggers = doc.Descendants("logger").ToList();
                if (loggers != null)
                {
                    foreach (var lg in loggers)
                    {
                        if (lg.Attribute("name").Value == loggerName)
                            lg.Remove();
                    }
                }

                var appenders = doc.Descendants("appender").ToList();
                if (appenders != null)
                {
                    foreach (var ap in appenders)
                    {
                        if (ap.Attribute("name").Value.Contains(loggerName))
                            ap.Remove();
                    }
                }

                doc.Save(configFilePath);

                ResetLoggerFile();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;

        }

        //先删除，都添加即为更新
        public bool updateLogger(LoggerEntity logger)
        {
            try
            {
                RemoveLogger(logger.loggerName);
                AddLogger(logger);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public bool ResetLoggerFile()
        {
            StreamReader objReader = new StreamReader(loggerFilePath);
            string sLine = "";
            StringBuilder fileString = new StringBuilder();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && !sLine.Equals("") && !sLine.Contains("public static string"))
                    fileString.Append(sLine + "\n");
            }
            objReader.Close();

            StringBuilder LoggerString = new StringBuilder();
            LoggerString.Append("/*replaceflag请不要删除这句注释*/ " + "\n"); 

            XDocument doc = XDocument.Load(configFilePath);
            var loggers = doc.Descendants("logger").ToList();
            if (loggers != null)
            {
                foreach (var lg in loggers)
                {
                   LoggerString.Append("\t\tpublic static string "+ lg.Attribute("name").Value + " = \"" + lg.Attribute("name").Value + "\";\n");
                }
            }
     

            //实例化一个文件流--->与写入文件相关联
            FileStream fs = new FileStream(loggerFilePath, FileMode.Create);
            //实例化一个StreamWriter-->与fs相关联
            StreamWriter sw = new StreamWriter(fs);
            //开始写入


            sw.Write(fileString.Replace("/*replaceflag请不要删除这句注释*/", LoggerString.ToString()));
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();

            return true;
        
        }


    }



    public class LoggerEntity
    {
        public LoggerEntity(){
            traceList = new Dictionary<string, bool>();
            traceList.Add("INFO",false);
            traceList.Add("DEBUG",false);
            traceList.Add("WARN",false);
            traceList.Add("ERROR",false);
            traceList.Add("FATAL",false);
            traceList.Add("AdoNetAppender_sqlserver",false);
        }
        public string loggerName { get; set; }
        public Dictionary<string,bool> traceList { get; set; }
        public string sqlConnstring { get; set; }
        public string saveDir { get; set; }

        public bool isAllTraceSetFalse()
        {
            var isAllFalse = true;
            foreach (var ap in  traceList)
            {
                if (ap.Value)
                {
                    isAllFalse = false;
                    break;
                }
            }

            return isAllFalse;

        }
 
    }
}

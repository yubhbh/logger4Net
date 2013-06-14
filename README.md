logger4Net
==========

easy to use log4net, a logger config tool

使用说明：
目的在于让开发人员不用太多理会log4net 内部配置。同时通过配置工具轻松管理log4net配置。程序员创建好相关业务的logger后，（如酒店业务需要记日志）
程序员只需要调用以下代码即：

Logger.Info(LoggerName.Hotel, "my info testmsg ");
Logger.Debug(LoggerName.Hotel, "my debug testmsg ");
Logger.Debug(LoggerName.Hotel, "my debug ", new Exception("here is debug exception"));
Logger.Error(LoggerName.Hotel, "my test msg ");
Logger.Error(LoggerName.Hotel, "my test msg ", new Exception("alex excetiopn coming"));
Logger.Warn(LoggerName.Hotel, "my Warn", new FieldAccessException("can't find file!"));

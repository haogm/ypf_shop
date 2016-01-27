using System;



public static class LogHelper
{
    private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");

    private static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");

    /// <summary>
    /// 信息日志
    /// </summary>
    /// <param name="info"></param>
    public static void WriteLog(string info)
    {

        if (loginfo.IsInfoEnabled)
        {
            loginfo.Info(info);
        }
    }
    /// <summary>
    /// 错误日志
    /// </summary>
    /// <param name="info"></param>
    /// <param name="se"></param>
    public static void WriteLog(string info, Exception se)
    {
        if (logerror.IsErrorEnabled)
        {
            logerror.Error(info, se);
        }
    }
  }

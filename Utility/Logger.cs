using System;

public enum LogLevel
{
    All = 0,
    Debug = 1,
    Info = 2,
    Error = 3,
    Off = 4
}

public enum LogType
{
    Debug = 1,
    Info = 2,
    Error = 3,
}

public class Logger
{
    private static LogLevel _level = LogLevel.All;
    
    /// <summary>
    /// Prints a formatted, leveled message to the console
    /// </summary>
    /// <param name="o">Any object with a properly defined ToString function</param>
    /// <param name="level">The log level, can be (from low to high) Debug, Info and Error</param>
    public static void Log(Object o, LogType level = LogType.Info)
    {
        switch (level)
        {
            case LogType.Debug:
                LogDebug(o);
                break;
            case LogType.Error:
                LogError(o);
                break;
            case LogType.Info:
                LogInfo(o);
                break;
        }
    }

    /// <summary>
    /// Changes the log level of the logger.
    /// All will show every message
    /// Debug will show level debug and lower message (same as all for now)
    /// Info will info and error messages
    /// Error will only show error messages
    /// Off will not show any messages at all
    /// </summary>
    /// <param name="level"></param>
    public void SetLogLevel(LogLevel level)
    {
        _level = level;
    }
    
    private static void LogDebug(object o)
    {
        if(_level <= LogLevel.Debug) PrintLog("DEBUG", o.ToString(), ConsoleColor.Yellow);
    }
    
    private static void LogInfo(object o)
    {
        if(_level <= LogLevel.Info) PrintLog("INFO",  o.ToString(), ConsoleColor.Green);
    }
    
    private static void LogError(object o)
    {
        if(_level <= LogLevel.Error) PrintLog("ERROR",  o.ToString(), ConsoleColor.Red);
    }

    private static void PrintLog(string tag, string message, ConsoleColor color)
    {
        string bracketTag = " [" + tag + "] ";
        ConsoleColor oldColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(GetFormattedTime() + bracketTag  + message);
        Console.ForegroundColor = oldColor;
    }

    private static string GetFormattedTime()
    {
        TimeSpan ts = TimeSpan.FromSeconds(Time.Now);
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        return "[" + elapsedTime + "]";
    }
}
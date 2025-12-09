using System;
using Godot;

public static class Log
{
    public static void Debug(params object[] message)
    {
        DebugLog(LogLevel.DEBUG, message);
    }
    public static void Info(params object[] message)
    {
        DebugLog(LogLevel.INFO, message);
    }
    public static void Warning(params object[] message)
    {
        DebugLog(LogLevel.WARNING, message);
    }
    public static void Error(params object[] message)
    {
        DebugLog(LogLevel.ERROR, message);
    }
    public static void DebugLog(LogLevel level, params object[] message)
    {
        var dateTime = DateTime.Now;
        string timeStamp = $"[{dateTime:yyyy-MM-dd HH:mm:ss}]";
        var callingMethod = new System.Diagnostics.StackTrace().GetFrame(2).GetMethod();
        string logMsg = $"{timeStamp} [{level}] [{callingMethod.DeclaringType.Name}] [{callingMethod.Name}]";

        string colour = "CYAN";

        switch (level)
        {
            case LogLevel.DEBUG:
                colour = "SILVER";
                break;
            case LogLevel.INFO:
                colour = "MAGENTA";
                break;
            case LogLevel.WARNING:
                colour = "ORANGE";
                break;
            case LogLevel.ERROR:
                colour = "RED";
                break;
            default:
                break;

        }
        
        GD.PrintRich([$"[color={colour}]{logMsg}[/color]", .. message]);
    }
}
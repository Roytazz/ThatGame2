﻿using System;

namespace GuildWars2Guild.Classes.Logger
{
    static class LogManager
    {
        public static void LogMessage(string message, LogType messageType = LogType.Message, bool closeApp = false) {
#if DEBUG
            LogMessage<ConsoleLogger>(message, messageType, closeApp);
#endif
#if !DEBUG
            LogMessage<FileLogger>(message, messageType, closeApp);
#endif
        }

        public static void LogException(Exception ex, string message, LogType messageType = LogType.Exception, bool closeApp = false) {
#if DEBUG
            LogException<ConsoleLogger>(ex, message, messageType, closeApp);
#endif
#if !DEBUG
            LogException<FileLogger>(ex, message, messageType, closeApp);
#endif
        }

        public static void LogMessage<T>(string message, LogType messageType = LogType.Message, bool closeApp = false) where T : ILogger, new() {
            new T().LogMessage(message, messageType);

            if(closeApp)
                CloseApplication();
        }

        public static void LogException<T>(Exception ex, string message, LogType messageType = LogType.Exception, bool closeApp = false) where T : ILogger, new() {
            new T().LogException(ex, message, messageType);

            if(closeApp)
                CloseApplication();
        }

        private static void CloseApplication() {
            Environment.Exit(1);
        }
    }
}
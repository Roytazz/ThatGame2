﻿using System;

namespace GuildWars2Guild.Classes.Logger
{
    interface ILogger
    {
        void LogMessage(string message, LogType messageType);
        void LogException(Exception ex, string message, LogType messageType);
    }

    public enum LogType
    {
        Info,       //Used for general info about processes starting or finishing
        Message,    //Used for weird or unusual situations that aren't error worthy
        Exception   //Used for exceptions
    }
}
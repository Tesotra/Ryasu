﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ryasu
{
    public static class RyasuLogger
    {
        public static void Log(string log)
        {
            Log(log, ConsoleColor.Gray);
        }

        public static void Log(string log, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"[RYASU {DateTime.Now.ToShortTimeString().ToUpper()}] {log}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

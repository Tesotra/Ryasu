using System;
using System.Collections.Generic;
using System.Linq;
using Ryasu.Game;

namespace Ryasu
{
    class Program
    {
        static void Main(string[] args)
        {
            RyasuLogger.Log("Initializing Ryasu...");
            RyasuGame.LaunchArguments = args.ToList();

            var game = new RyasuGame();
            game.Run();
        }
    }
}

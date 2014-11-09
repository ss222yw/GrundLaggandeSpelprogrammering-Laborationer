#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using Game2.controller;
#endregion

namespace Game2
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new MonoGameController())
                game.Run();
        }
    }
#endif
}

using AzemitologaUzdevums.Application;
using AzemitologaUzdevums.Engine.Core;
using System;

namespace AzemitologaUzdevums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisableConsoleQuickEdit.Go();
            Console.CursorVisible = false;

            var azemitologaUzdevums = new Core(new App());
            azemitologaUzdevums.Start();
        }
    }
}

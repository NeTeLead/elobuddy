﻿using System;
using System.Diagnostics;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace AutoRestarter
{
    class Program
    {
        static int time;
        static string botPath;

        static void Main(string[] args)
        {
            Console.WriteLine("Time for each restart (sec): ");
            time = Convert.ToInt32(Console.ReadLine()) * 1000;

            foreach (string file in Directory.EnumerateFiles(Environment.CurrentDirectory, "bot"))
            {
                if (Path.GetExtension(file) == ".exe")
                {
                    botPath = file;
                    break;
                }
            }

            while (true)
            {
                foreach (Process sysProcess in Process.GetProcesses())
                {
                    if (sysProcess.ProcessName.Contains("bot"))
                    {
                        sysProcess.Kill();
                        Console.WriteLine("[{0:hh:mm:ss}] closing bot..", DateTime.Now);
                    }
                    else if (sysProcess.ProcessName.Contains("League of Legends"))
                    {
                        sysProcess.Kill();
                        Console.WriteLine("[{0:hh:mm:ss}] closing LoL..", DateTime.Now);
                    }
                }

                Process.Start(botPath);
                Console.WriteLine("[{0:hh:mm:ss}] initializing bot..", DateTime.Now);

                System.Threading.Thread.Sleep(time);
            }
        }
    }
}

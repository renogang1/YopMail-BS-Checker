using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace YopmailChecker
{
    public static class Program 
    {         
        public static void Main()
        {
            string name = Console.ReadLine();
            Console.WriteLine("Wait...");
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            p.StartInfo(@"./yogo.exe");
            info.Arguments("inbox list " + name + " 10");
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            p.Start();
            string mailoutput = p.StandardOutput.ReadToEnd();
            if (mailoutput.Contains("Supercell ID"))
            {
            	Console.Clear();
            	Console.Beep(1000, 50);
            	Console.WriteLine(name + "@yopmail.com Connected to SCID!");
            }
            else
            {
            	Console.Clear();
            	Console.Beep(200, 50);
            	Console.WriteLine(name + "@yopmail.com NOT connected to SCID!");
            }
        }
    }
}

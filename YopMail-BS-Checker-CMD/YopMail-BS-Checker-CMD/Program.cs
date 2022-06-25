using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
namespace YopMail_BS_Checker_CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            /*using (FileStream fs = new FileStream("names.json", FileMode.OpenOrCreate))
            {
                BSNames? names = JsonSerializer.Deserialize<BSNames>(fs);
            }
            */
            try
            {
                Process[] processes = Process.GetProcessesByName("yogo");
                if (processes.Length > 0)
                    processes[0].CloseMainWindow();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"./yogo.exe");
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.Arguments = "inbox list " + name + " 20";
            p.Start();
            StreamReader reader = p.StandardOutput;
            string mailoutput = reader.ReadToEnd();
            if (mailoutput.Contains("Supercell ID"))
            {
                Console.Clear();
                Console.Beep(1000, 100);
                Console.WriteLine("Supercell ID connected to this email!");
                Console.WriteLine("");
                Thread.Sleep(5000);
                Environment.Exit(-1);
                /*Console.WriteLine("Do you want to get SCID code? y/n");
                string inputkey = Console.ReadLine();
                if (inputkey == "y")
                {
                    Console.Clear();
                    p.StartInfo.Arguments = "inbox show " + name + " 1";
                    p.Start();
                    string pattern = @"←\[35m←\[0m|←\[33m|←\[0m";
                    string mailinput = reader.ReadToEnd();
                    Console.WriteLine(mailinput);
                    string aa = String.Empty;
                    string bb = Regex.Replace(mailinput, pattern, aa);
                    string[] cc = aa.Split("[");
                    string dd = cc[1];
                    string[] ee = dd.Split("]");
                    Console.WriteLine(ee[0]);
                }
                else
                {
                    Environment.Exit(-1);
                }*/
            }
            else
            {
                Console.Clear();
                Console.Beep(350, 100);
                Console.WriteLine("Supercell ID not connected to this email! Try again");
                Thread.Sleep(5000);
                Environment.Exit(-1);
            }
            p.WaitForExit();
        }
        class BSNames
        {
            public string names { get; set; }
        }
    }
}

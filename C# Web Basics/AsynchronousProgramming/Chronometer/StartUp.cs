using System;
using System.Text;

namespace Chronometer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();
            string command = Console.ReadLine().ToLower();

            while (command != "exit")
            {
                if (command == "start")
                {
                    chronometer.Start();
                }
                else if (command == "stop")
                {
                    chronometer.Stop();
                }
                else if (command == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (command == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
                else if (command == "reset")
                {
                    chronometer.Reset();
                }
                else if (command == "laps")
                {
                    StringBuilder sb = new StringBuilder();

                    if (chronometer.Laps.Count == 0)
                    {
                        sb.AppendLine("Laps: no laps");
                    }
                    else
                    {
                        foreach (var lap in chronometer.Laps)
                        {
                            sb.AppendLine($"0. {lap}");
                        }
                    }             

                    Console.WriteLine(sb.ToString().TrimEnd());
                }

                command = Console.ReadLine().ToLower();
            }
        }
    }
}

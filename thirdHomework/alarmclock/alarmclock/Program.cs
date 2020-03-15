using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace alarmclock
{
    class Program
    {

        public delegate void ClockHandler(ClockEventArgs args);

        public class ClockEventArgs
        {
            private DateTime currentTime;
            private DateTime alarmTime;

            public DateTime CurrentTime
            {
                get
                {
                    return currentTime;
                }
                set
                {
                    currentTime = value;
                }
            }
            public DateTime AlarmTime
            {
                get
                {
                    return alarmTime;
                }
                set
                {
                    alarmTime = value;
                }
            }
        }

        public class ClockEvent
        {
            private bool isPause = true;
            public event ClockHandler Tick;
            public event ClockHandler Alarm;

            public void ShowTime(DateTime alarmColck)
            {
                ClockEventArgs args = new ClockEventArgs();
                args.AlarmTime = alarmColck;
                while (true)
                {
                    args.CurrentTime = System.DateTime.Now;
                    if (DateTime.Compare(args.CurrentTime, args.AlarmTime) >= 0 && isPause)
                    {
                        Console.WriteLine("Dou Dou Dou Dou!!!!!!");
                        Console.WriteLine("Get up now!!!!!!");
                        Console.WriteLine("Press any key to ditch the alarm");

                        if (Alarm != null)
                        {
                            Alarm(args);
                        }

                        if (Console.ReadLine() != null)
                        {
                            isPause = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"The current time is {DateTime.Now}");
                        if (Tick != null)
                        {
                            Tick(args);
                        }
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        static void Main(string[] args)
        {
            var clockevent = new ClockEvent();
            DateTime alarmTime = new DateTime();
            int year, month, day, hour, minute, second;
            Console.WriteLine("Please enter the accurate alarm time of your clock");
            Console.WriteLine("Enter year, month, day, hour ,minute and second IN TURN and seperate them with the ENTER key");
            try
            {
                year = int.Parse(Console.ReadLine());
                month = int.Parse(Console.ReadLine());
                day = int.Parse(Console.ReadLine());
                hour = int.Parse(Console.ReadLine());
                minute = int.Parse(Console.ReadLine());
                second = int.Parse(Console.ReadLine());
                alarmTime = new DateTime(year, month, day, hour, minute, second);
                Console.WriteLine($"You have set the alarm time as {alarmTime}");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error:the time you enter is out of range");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error:the format of time you enter is wrong");
            }
            finally
            {
                clockevent.ShowTime(alarmTime);
            }
        }

    }
}

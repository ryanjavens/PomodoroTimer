using System;
using System.Threading.Tasks;

namespace PomodoroTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Values below in milliseconds
            // 25 minutes
            //const int INTERVAL_TIME = 1500000;
            const int INTERVAL_TIME = 5000;
            // 5 minutes
            const int SHORT_BREAK_TIME = 300000;
            // 30 minutes
            const int LONG_BREAK_TIME = 1800000;
            const int NUMBER_OF_INTERVALS = 4;

            int currentPhase = 1;

            Console.Write("Enter the name of your task: ");
            string taskName = Console.ReadLine();
            // TODO: Input validation

            while(currentPhase <= NUMBER_OF_INTERVALS)
            {
                pomodoroInterval(INTERVAL_TIME, taskName, currentPhase, NUMBER_OF_INTERVALS);
                // Play sound
                // Start break
                currentPhase++;
            }

            void pomodoroInterval(int duration, string taskName, int phaseNumber, int totalPhaseCount)
            {
                Console.Clear();
                Console.WriteLine($"Phase {phaseNumber} of {totalPhaseCount}: Working on {taskName}");
                Console.Write("Time remaining: ");
                while(duration != 0)
                {
                    Console.SetCursorPosition(16, 1);
                    Console.Write(milliToMinuteSecond(duration));
                    System.Threading.Thread.Sleep(1000);
                    // Reduce duration by 1 second
                    duration = duration - 1000;
                }
            }

            string milliToMinuteSecond(int milliseconds)
            {
                int minutes = (milliseconds / 1000) / 60;
                int seconds = (milliseconds / 1000) % 60;

                return $"{minutes}:{String.Format("{0:00}",seconds)}";
            }
        }
    }
}

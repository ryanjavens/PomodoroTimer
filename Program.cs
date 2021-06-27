using System;

namespace PomodoroTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Values below in milliseconds
            // 25 minutes
            const int INTERVAL_TIME = 1500000;
            // 5 minutes
            const int SHORT_BREAK_TIME = 300000;
            // 30 minutes
            const int LONG_BREAK_TIME = 1800000;
            const int NUMBER_OF_INTERVALS = 4;

            int currentPhase = 1;
            bool keepGoing = true;
            string keepGoingInput = "";

            Console.Write("Enter the name of your task: ");
            string taskName = Console.ReadLine();

            while(keepGoing)
            {
                while (currentPhase <= NUMBER_OF_INTERVALS)
                {
                    pomodoroInterval(INTERVAL_TIME, taskName, currentPhase, NUMBER_OF_INTERVALS);
                    // Start break
                    if(currentPhase < 4)
                    {
                        // Skip short break at the end
                        pomodoroInterval(SHORT_BREAK_TIME, "SHORT BREAK", currentPhase, NUMBER_OF_INTERVALS);
                    }
                    currentPhase++;
                }
                // Use NUMBER_OF_INTERVALS instead of currentPhase for phase number since it will exceed # of phases to break out of loop above
                pomodoroInterval(LONG_BREAK_TIME, "LONG BREAK", NUMBER_OF_INTERVALS, NUMBER_OF_INTERVALS);

                Console.Clear();
                Console.WriteLine("Congratulations! You finished a pomodoro sprint. Would you like to keep going?");
                Console.Write("Please enter Y for yes, or anything else for no: ");
                keepGoingInput = Console.ReadLine();
                if(keepGoingInput == "Y" || keepGoingInput == "y") {
                    keepGoing = true;
                    currentPhase = 1;
                }
                else
                {
                    keepGoing = false;
                }
            }

            Environment.Exit(0);


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
                    duration -= 1000;
                }
                Console.Beep();
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

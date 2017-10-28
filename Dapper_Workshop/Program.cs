using Common.Enum;
using Examples.Utility;
using Exercices.Utility;
using System;
using System.Threading;

namespace Dapper_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            E_ActivityType Activity;
            do
            {
                Console.Clear();
                Console.WriteLine("Type your choice E - example, W - workshop exercice, Q - quit current app.");
                var _choice = Console.ReadKey().KeyChar;
                _choice = char.ToLower(_choice);
                Console.WriteLine();
                switch (_choice)
                {
                    case 'e':
                        Console.WriteLine("You choosed to run an example");
                        Activity = E_ActivityType.Example;
                        break;
                    case 'w':
                        Console.WriteLine("You choosed to run an exercice");
                        Activity = E_ActivityType.Exercice;
                        break;
                    case 'q':
                        Console.WriteLine("You choosed to quit");
                        Activity = E_ActivityType.Quit;
                        break;
                    default: continue;
                }
                switch (Activity)
                {
                    case E_ActivityType.Example:
                        new ExampleChooser().Choose();
                        break;
                    case E_ActivityType.Exercice:
                        new ExerciceChooser().Choose();
                        break;
                    default: break;
                }
                if (Activity == E_ActivityType.Quit)
                    break;
            }
            while (1 == 1);
            Thread.Sleep(2000);
        }
    }
}

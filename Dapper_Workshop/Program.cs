using Common.Enum;
using Examples.Utility;
using Exercices.Utility;
using System;
using System.Linq;
using System.Threading;

namespace Dapper_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            if(TestIfDapperWorkShopOn())
            {
                Console.Clear();
                Console.WriteLine("Aplikacja jest już uruchomiona");
                CloseThisApp();
            }
            new DapperWorkshopInitializer().InitializeDapperWorkshops();
            EActivityType Activity;
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
                        Activity = EActivityType.Example;
                        break;
                    case 'w':
                        Console.WriteLine("You choosed to run an exercice");
                        Activity = EActivityType.Exercice;
                        break;
                    case 'q':
                        Console.WriteLine("You choosed to quit");
                        Activity = EActivityType.Quit;
                        break;
                    default: continue;
                }
                switch (Activity)
                {
                    case EActivityType.Example:
                        new ExampleProcessor().ChooseAndShow();
                        break;
                    case EActivityType.Exercice:
                        new ExerciceFactory().Choose();
                        break;
                    default: break;
                }
                if (Activity == EActivityType.Quit)
                    break;
            }
            while (1 == 1);
            CloseThisApp();
        }

        private static bool TestIfDapperWorkShopOn() =>
            System.Diagnostics.Process.GetProcessesByName("Dapper_Workshop").Count() >= 1;

        private static void CloseThisApp()
        {
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
}

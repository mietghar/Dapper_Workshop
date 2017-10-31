using System;
using Examples.Examples.Interface;
using Common.Utility;
using DAL.Repository;

namespace Examples.Examples.Example_1
{
    public class Example_1 : IExampleChoice
    {
        private readonly Example1Repository Repository;
        public Example_1()
        {
            Repository = new Example1Repository(ConnectionStore.ConnectionString);
        }
        public void Show()
        {
            Console.WriteLine("Example 1\n\n");
            Console.WriteLine("Example shows Query method to get strongly typed instance on an mapped object:\n\n");

            try
            {
                Console.WriteLine("Single object:");
                var _employee = Repository.GetPerson();
                var _employees = Repository.GetPeople();
                ConsoleExtension.WriteObject(_employee);
                Console.WriteLine("\n\nPress any buttons to show all objects:/n");
                Console.ReadKey();
                Console.WriteLine();
                ConsoleExtension.WriteObject(_employees);
            }
            catch (Exception exception)
            {
                Console.WriteLine(ConnectionStore.ConnectionErrorProvider(exception.Message));
            }

            GetBackChooser.GetBack();
        }
    }
}

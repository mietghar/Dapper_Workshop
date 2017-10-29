using System;
using Examples.Examples.Interface;
using Common.Utility;
using DAL.Repository;

namespace Examples.Examples.Example_1
{
    public class Example_1 : IExampleChoice
    {
        private readonly RepositoryExample_1 Repository;
        public Example_1()
        {
            Repository = new RepositoryExample_1(ConnectionStore.ConnectionString);
        }
        public void Show()
        {
            Console.WriteLine("Example 1\n\n");
            Console.WriteLine("Example shows Query method to get strongly typed instance on an mapped object:\n\n");

            try
            {
                Console.WriteLine("Single object:");
                var _person = Repository.GetPerson();
                var _people = Repository.GetPeople();
                ConsoleExtension.WriteObject(_person);
                Console.WriteLine("\n\nPress any buttons to show all objects:/n");
                Console.ReadKey();
                Console.WriteLine();
                ConsoleExtension.WriteObject(_people);
            }
            catch (Exception exception)
            {
                Console.WriteLine(ConnectionStore.ConnectionErrorProvider(exception.Message));
            }

            GetBackChooser.GetBack();
        }
    }
}

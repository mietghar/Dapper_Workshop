using System;
using Examples.Examples.Interface;
using Common.Utility;
using DAL.Repository;
using Common.Enum;
using Examples.Utility;

namespace Examples.Examples.Example_1
{
    public class Example_1 : IExampleChoice
    {
        private readonly Example1Repository _repository;
        public Example_1()
        {
            _repository = new Example1Repository(ConnectionStore.ConnectionString);
        }
        public void Show()
        {
            Console.WriteLine("Example 1\n\n");
            Console.WriteLine("Example shows Query method to get strongly typed instance on an mapped object:\n\n");

            try
            {
                Console.WriteLine("Single object:");
                var employee = _repository.GetPerson();
                var employees = _repository.GetPeople();
                ConsoleExtension.WriteObject(employee);
                Console.WriteLine("\n\nPress any buttons to show all objects:/n");
                Console.ReadKey();
                Console.WriteLine();
                ConsoleExtension.WriteObject(employees);
                Console.WriteLine();
                bool result = false;
                do
                {
                    Console.WriteLine("The question is: Which ORM is faster Dapper, Entity Framework or Linq2SQL?");
                    Console.WriteLine("Press 1 for the first, 2 for the second and 3 for the third answer:");
                    var fasterORMQuestionAnswer = Console.ReadKey().KeyChar;
                    result = new QuestionAnswerHandler(EQuestionType.FastestORM)
                        .HandleAnswer(fasterORMQuestionAnswer);
                    Console.WriteLine();
                }
                while (!result);
            }
            catch (Exception exception)
            {
                Console.WriteLine(ConnectionStore.ConnectionErrorProvider(exception.Message));
            }

            GetBackChooser.GetBack();
        }
    }
}

using Common.Enum;
using Common.Utility;
using DAL.Repository;
using Examples.Examples.Interface;
using Examples.Utility;
using System;
using System.Diagnostics;

namespace Examples.Examples.Example_3
{
    public class Example_3 : IExampleChoice
    {
        private readonly Example3Repository _repository;
        private readonly InitializationRepository _initializationRepository;
        public Example_3()
        {
            _repository = new Example3Repository(ConnectionStore.ConnectionString);
            _initializationRepository = new InitializationRepository(ConnectionStore.ConnectionString);
        }

        public void Show()
        {
            Console.WriteLine("Example 3\n\n");
            Console.WriteLine("Example shows \"QueryFirst\" method to select data from Employee table:\n\n");

            try
            {
                Console.WriteLine("QueryFirst method execution, press any key to begin:");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("I'm working, please be patient...\n");
                _repository.PopulateEmployeeWithFakeData();
                var watchDapper = new Stopwatch();
                watchDapper.Start();
                var dapperMethod = _repository.GetFirstEmployee();
                watchDapper.Stop();
                var watchLinq = new Stopwatch();
                watchLinq.Start();
                var linqMethod = _repository.GetFirstEmployeeFiltered();
                watchLinq.Stop();
                ConsoleExtension.WriteObject(dapperMethod);
                Console.WriteLine($"\nElapsed time: {watchDapper.ElapsedMilliseconds}\n");
                ConsoleExtension.WriteObject(linqMethod);
                Console.WriteLine($"\nElapsed time: {watchLinq.ElapsedMilliseconds}\n");
                bool result = false; ;
                do
                {
                    Console.WriteLine("The question is: Which of two queries above was a Dapper query?");
                    Console.WriteLine("Press 1 for the first and 2 for the second answer:");
                    var dapperQuestionAnswer = Console.ReadKey().KeyChar;
                    result = new QuestionAnswerHandler(EQuestionType.QueryFirstQuestion)
                        .HandleAnswer(dapperQuestionAnswer);
                    Console.WriteLine();
                }
                while (!result);
                Console.WriteLine("\n");
                Console.WriteLine("Clearing db table");
                _repository.ClearAllEmployeeData();
                Console.WriteLine("Db table cleared");
                Console.WriteLine("Reinitializing db tables");
                _initializationRepository.Initialize();
                Console.WriteLine("Db tables reinitialized");
            }
            catch (Exception exception)
            {
                Console.WriteLine(ConnectionStore.ConnectionErrorProvider(exception.Message));
            }

            GetBackChooser.GetBack();
        }
    }
}

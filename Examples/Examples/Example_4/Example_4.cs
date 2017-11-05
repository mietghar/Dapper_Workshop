using Common.Enum;
using Common.Utility;
using DAL.Repository;
using Examples.Examples.Interface;
using Examples.Utility;
using System;

namespace Examples.Examples.Example_4
{
    class Example_4 : IExampleChoice
    {
        private readonly Example4Repository _repository;
        private readonly InitializationRepository _initializationRepository;
        public Example_4()
        {
            _repository = new Example4Repository(ConnectionStore.ConnectionString);
            _initializationRepository = new InitializationRepository(ConnectionStore.ConnectionString);
        }

        public void Show()
        {
            Console.WriteLine("Example 4\n\n");
            Console.WriteLine("Example shows \"QueryFirstOrDefault\" method to select data from Employee Table:\n\n");

            try
            {
                Console.WriteLine("First, answer the question\n");
                bool result = false; ;
                do
                {
                    Console.WriteLine("The question is: What will happen in case if we use QueryFirsOrDefault method on more than 1 records?");
                    Console.WriteLine("Press 1 if it will return null, press 2 if it will return default value of queried type and press 3 if it will return first of found records");
                    var dapperQuestionAnswer = Console.ReadKey().KeyChar;
                    result = new QuestionAnswerHandler(EQuestionType.QueryFirstOrDefaultQuestion)
                        .HandleAnswer(dapperQuestionAnswer);
                    Console.WriteLine();
                }
                while (!result);

                _initializationRepository.Initialize();
                Console.WriteLine("QueryFirstOrDefault method execution, press any key to begin:");
                Console.ReadKey();
                Console.WriteLine("\nFirst or default object if found more than 1 records:");
                var firstOrDefaultEmployee = _repository.GetFirstOrDefaultEmployee();
                ConsoleExtension.WriteDynamicObject(firstOrDefaultEmployee);
                Console.WriteLine("\nSecond case, press any key to proceed:");
                Console.ReadKey();
                Console.WriteLine("\n");
                Console.WriteLine("Clearing db table");
                _repository.ClearAllEmployeeData();
                Console.WriteLine("Db table cleared");
                Console.WriteLine("\nFirst or default object if no records found:");
                var firstOrDefaultEmployeeIfEmpty = _repository.GetFirstOrDefaultEmployee();
                ConsoleExtension.WriteDynamicObject(firstOrDefaultEmployeeIfEmpty);
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

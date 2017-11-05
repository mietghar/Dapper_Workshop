using Common.Enum;
using Common.Utility;
using DAL.Repository;
using Examples.Examples.Interface;
using Examples.Utility;
using System;

namespace Examples.Examples.Example_6
{
    public class Example_6 : IExampleChoice
    {
        private readonly Example6Repository _repository;
        private readonly InitializationRepository _initializationRepository;
        public Example_6()
        {
            _repository = new Example6Repository(ConnectionStore.ConnectionString);
            _initializationRepository = new InitializationRepository(ConnectionStore.ConnectionString);
        }
        public void Show()
        {
            Console.WriteLine("Example 6\n\n");
            Console.WriteLine("Example shows \"QuerySingleOrDefault\" method to select data from Address table:\n\n");

            try
            {
                Console.WriteLine("First, answer the question\n");
                bool result = false; ;
                do
                {
                    Console.WriteLine("The question is: What will happen in case if we use QuerySingleOrDefault method on more than 1 records?");
                    Console.WriteLine("Press 1 if it will return null, press 2 if it will return an exception and press 3 if it will return any single of found records");
                    var dapperQuestionAnswer = Console.ReadKey().KeyChar;
                    result = new QuestionAnswerHandler(EQuestionType.QuerySingleOrDefaultQuestion)
                        .HandleAnswer(dapperQuestionAnswer);
                    Console.WriteLine();
                }
                while (!result);

                _initializationRepository.Initialize();
                Console.WriteLine("QuerySingleOrDefault method execution, press any key to begin:");
                Console.ReadKey();
                Console.WriteLine("\nSingleOrDefault object if found more than 1 records:");
                try
                {
                    var singleIfMany = _repository.GetSingleOrDefaultAddress();
                    ConsoleExtension.WriteObject(singleIfMany);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"QuerySingleOrDefault method has thrown an exception: \n\n{exception.Message}");
                }
                Console.WriteLine("\nSecond case, press any key to proceed:");
                Console.ReadKey();
                Console.WriteLine("\n");
                Console.WriteLine("Clearing db table");
                _repository.ClearAllAddressData();
                Console.WriteLine("Db table cleared");
                _repository.AddSingleFakeAddress();
                Console.WriteLine("Added single fake address to Address table");
                Console.WriteLine("\nSingleOrDefault object if single record found:");
                try
                {
                    var single = _repository.GetSingleOrDefaultAddress();
                    ConsoleExtension.WriteObject(single);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"QuerySingleOrDefault method has thrown an exception: \n\n{exception.Message}");
                }
                Console.WriteLine("\nThird case, press any key to proceed:");
                Console.ReadKey();
                Console.WriteLine("\n");
                Console.WriteLine("Clearing db table");
                _repository.ClearAllAddressData();
                Console.WriteLine("Db table cleared");
                Console.WriteLine("\nSingleOrDefault object if no records found:");
                try
                {
                    var singleIfEmpty = _repository.GetSingleOrDefaultAddress();
                    ConsoleExtension.WriteObject(singleIfEmpty);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"QuerySingleOrDefault method has thrown an exception: \n\n{exception.Message}");
                }
                Console.WriteLine("\n\nReinitializing db tables");
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

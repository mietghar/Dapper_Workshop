using Common.Utility;
using DAL.Repository;
using Examples.Examples.Interface;
using System;

namespace Examples.Examples.Example_7
{
    public class Example_7 : IExampleChoice
    {
        private readonly Example7Repository _repository;
        private readonly InitializationRepository _initializationRepository;
        public Example_7()
        {
            _repository = new Example7Repository(ConnectionStore.ConnectionString);
            _initializationRepository = new InitializationRepository(ConnectionStore.ConnectionString);
        }
        public void Show()
        {
            Console.WriteLine("Example 7\n\n");
            Console.WriteLine("Example shows \"QueryMultiple\" method to select multiple data from db:\n\n");

            try
            {
                _initializationRepository.Initialize();
                Console.WriteLine("QueryMultiple method execution, press any key to begin:");
                Console.ReadKey();
                Console.WriteLine("\nQueryMultiple anonymous object after connecting two objects from query result:");
                try
                {
                    var multiple = _repository.GetEmployeeAndItsAddress();
                    ConsoleExtension.WriteObject(multiple);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"nQueryMultiple method has thrown an exception: \n\n{exception.Message}");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(ConnectionStore.ConnectionErrorProvider(exception.Message));
            }

            GetBackChooser.GetBack();
        }
    }
}

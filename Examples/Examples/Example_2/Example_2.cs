using Examples.Examples.Interface;
using DAL.Repository;
using Common.Utility;
using System;

namespace Examples.Examples.Example_2
{
    public class Example_2 : IExampleChoice
    {
        private readonly Example2Repository _repository;
        public Example_2()
        {
            _repository = new Example2Repository(ConnectionStore.ConnectionString);
        }

        public void Show()
        {
            Console.WriteLine("Example 2\n\n");
            Console.WriteLine("Example shows \"Execute\" method to insert data through stored SQL DB procedure passing anonymous parameters:\n\n");

            try
            {
                Console.WriteLine("Procedure execution, press any key to begin:");
                Console.ReadKey();
                Console.WriteLine();
                var rows = _repository.GetInsertQueryRows();
                Console.WriteLine(string.Format("Number of affected rows: {0}",(rows <=0)? 0 : rows));
            }
            catch (Exception exception)
            {
                Console.WriteLine(ConnectionStore.ConnectionErrorProvider(exception.Message));
            }

            GetBackChooser.GetBack();
        }
    }
}

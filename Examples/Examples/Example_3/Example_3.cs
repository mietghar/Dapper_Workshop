using Common.Utility;
using DAL.Repository;
using Examples.Examples.Interface;
using System;
using System.Diagnostics;

namespace Examples.Examples.Example_3
{
    public class Example_3 : IExampleChoice
    {
        private readonly Example3Repository Repository;
        public Example_3()
        {
            Repository = new Example3Repository(ConnectionStore.ConnectionString);
        }

        public void Show()
        {
            Console.WriteLine("Example 3\n\n");
            Console.WriteLine("Example shows \"QueryFirst\" method to select data from Employee Table:\n\n");

            try
            {
                Console.WriteLine("QueryFirst method execution, press any key to begin:");
                Console.ReadKey();
                Console.WriteLine();
                Repository.PopulateEmployeeWithFakeData();
                var _watchDapper = new Stopwatch();
                _watchDapper.Start();
                var _dapperMethod = Repository.GetFirstEmployee();
                _watchDapper.Stop();
                var _watchLinq = new Stopwatch();
                _watchLinq.Start();
                var _linqMethod = Repository.GetFirstEmployeeFiltered();
                _watchLinq.Stop();
                ConsoleExtension.WriteObject(_dapperMethod);
                Console.WriteLine($"\nElapsed time: {_watchDapper.ElapsedMilliseconds}\n");
                ConsoleExtension.WriteObject(_linqMethod);
                Console.WriteLine($"\nElapsed time: {_watchLinq.ElapsedMilliseconds}\n");
            }
            catch (Exception exception)
            {
                Console.WriteLine(ConnectionStore.ConnectionErrorProvider(exception.Message));
            }

            GetBackChooser.GetBack();
        }
    }
}

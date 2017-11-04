using Common.Enum;
using Examples.Examples.Interface;
using System;

namespace Examples.Utility
{
    public class ExampleProcessor
    {
        IExampleChoice Choice = null;
        EExample Example = EExample.Quit;

        public void ChooseAndShow()
        {
            var enumEExampleMemberCount = Enum.GetNames(typeof(EExample)).Length-1;
            var choosed = true;
            do
            {
                Console.Clear();
                Console.WriteLine($"Example - type your choice number from 1 to {enumEExampleMemberCount} and b if want you to get back");
                var _choice = Console.ReadKey().KeyChar;
                _choice = char.ToLower(_choice);
                Console.WriteLine();
                choosed = true;
                switch (_choice)
                {
                    case 'b':
                        break;
                    case '1':
                        Example = EExample.Example_1;
                        break;
                    case '2':
                        Example = EExample.Example_2;
                        break;
                    case '3':
                        Example = EExample.Example_3;
                        break;
                    case '4':
                        Example = EExample.Example_4;
                        break;
                    default:
                        choosed = false;
                        break;
                }
                if (choosed) break;
            }
            while (1 == 1);

            ExampleFactory exampleFactory = new ExampleFactory();
            Choice = exampleFactory.ChooseAndShow(Example);
            Choice?.Show();
        }
    }
}

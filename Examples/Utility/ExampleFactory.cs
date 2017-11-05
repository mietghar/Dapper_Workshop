using Common.Enum;
using Examples.Examples.Example_1;
using Examples.Examples.Example_2;
using Examples.Examples.Example_3;
using Examples.Examples.Example_4;
using Examples.Examples.Example_5;
using Examples.Examples.Example_6;
using Examples.Examples.Interface;

namespace Examples.Utility
{
    public class ExampleFactory
    {
        public virtual IExampleChoice ChooseAndShow(EExample example)
        {
            IExampleChoice choice = null;
            switch (example)
            {
                case EExample.Example_1:
                    choice = new Example_1();
                    break;
                case EExample.Example_2:
                    choice = new Example_2();
                    break;
                case EExample.Example_3:
                    choice = new Example_3();
                    break;
                case EExample.Example_4:
                    choice = new Example_4();
                    break;
                case EExample.Example_5:
                    choice = new Example_5();
                    break;
                case EExample.Example_6:
                    choice = new Example_6();
                    break;
                case EExample.Quit:
                default: break;
            }

            return choice;
        }
    }
}

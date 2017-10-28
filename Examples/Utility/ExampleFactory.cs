using Common.Enum;
using Examples.Examples.Example_1;
using Examples.Examples.Example_2;
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
                case EExample.Quit:
                default: break;
            }

            return choice;
        }
    }
}

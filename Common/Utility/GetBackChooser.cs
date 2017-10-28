using System;

namespace Common.Utility
{
    public class GetBackChooser
    {
        public static void GetBack()
        {
            var GetBack = false;
            do
            {
                Console.WriteLine("\n\nPress b to get back");
                var _choice = Console.ReadKey().KeyChar;
                _choice = char.ToLower(_choice);
                switch (_choice)
                {
                    case 'b':
                        GetBack = true;
                        break;
                    default:
                        break;
                }
                if (GetBack) break;
            }
            while (1 == 1);
        }
    }
}

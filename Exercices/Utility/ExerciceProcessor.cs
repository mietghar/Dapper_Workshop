using Common.Enum;
using Exercices.Exercices.Interface;
using System;

namespace Exercices.Utility
{
    public class ExerciceProcessor
    {
        IExerciceChoice Choice = null;
        EExercice Exercice = EExercice.Quit;

        public void ChooseAndShow()
        {
            var enumEExerciceMemberCount = Enum.GetNames(typeof(EExercice)).Length - 1;
            var choosed = true;
            do
            {
                Console.Clear();
                Console.WriteLine($"Exercice - type your choice number from 1 to {enumEExerciceMemberCount} and b if want you to get back");
                var _choice = Console.ReadKey().KeyChar;
                _choice = char.ToLower(_choice);
                Console.WriteLine();
                choosed = true;
                switch (_choice)
                {
                    case 'b':
                        break;
                    case '1':
                        Exercice = EExercice.Exercice_1;
                        break;
                    case '2':
                        Exercice = EExercice.Exercice_2;
                        break;
                    default:
                        choosed = false;
                        break;
                }
                if (choosed) break;
            }
            while (1 == 1);

            ExerciceFactory exerciceFactory = new ExerciceFactory();
            Choice = exerciceFactory.ChooseAndShow(Exercice);
            Choice?.RunExercice();
        }
    }
}

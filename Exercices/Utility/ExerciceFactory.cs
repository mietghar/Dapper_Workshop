using Common.Enum;
using Exercices.Exercices.Exercice_1;
using Exercices.Exercices.Exercise_2;
using Exercices.Exercices.Exercise_3;
using Exercices.Exercices.Interface;

namespace Exercices.Utility
{
    public class ExerciceFactory
    {
        public ExerciceFactory()
        {

        }

        public virtual IExerciceChoice ChooseAndShow(EExercice exercice)
        {
            IExerciceChoice choice = null;
            switch (exercice)
            {
                case EExercice.Exercice_1:
                    choice = new Exercice_1();
                    break;
                case EExercice.Exercice_2:
                    choice = new Exercice_2();
                    break;
                case EExercice.Exercice_3:
                    choice = new Exercice_3();
                    break;
                case EExercice.Quit:
                default: break;
            }

            return choice;
        }
    }
}

using System;
using Common.Enum;
using Common.Utility;

namespace Examples.Utility
{
    public class QuestionAnswerHandler
    {
        private readonly EQuestionType _questionType;
        public QuestionAnswerHandler(EQuestionType questionType)
        {
            _questionType = questionType;
        }

        public bool HandleAnswer(char answer)
        {
            switch (answer)
            {
                case '1':
                    switch (_questionType)
                    {
                        case EQuestionType.QueryFirstQuestion:
                            PrintAnswerInterpretation(_questionType, true);
                            break;
                        default: break;
                    }
                    return true;
                case '2':
                    switch (_questionType)
                    {
                        case EQuestionType.QueryFirstQuestion:
                            PrintAnswerInterpretation(_questionType, false);
                            break;
                        default: break;
                    }
                    return true;

                default: return false;
            }
        }

        private void PrintAnswerInterpretation(EQuestionType questionType, bool result)
        {
            Console.WriteLine();
            Console.WriteLine(result ? "Good answer" : "Wrong answer");
            using (PointsProcessor processor = new PointsProcessor())
            {
                processor.ProcessPoints(questionType, result);
                processor.PrintPointsState();
            }                
        }
    }
}

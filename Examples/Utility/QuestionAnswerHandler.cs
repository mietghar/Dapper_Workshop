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
                            return true;
                        case EQuestionType.FastestORM:
                            PrintAnswerInterpretation(_questionType, true);
                            return true;
                        case EQuestionType.QueryFirstOrDefaultQuestion:
                            PrintAnswerInterpretation(_questionType, false);
                            return true;
                        default: return false;
                    }
                case '2':
                    switch (_questionType)
                    {
                        case EQuestionType.QueryFirstQuestion:
                            PrintAnswerInterpretation(_questionType, false);
                            return true;
                        case EQuestionType.FastestORM:
                            PrintAnswerInterpretation(_questionType, false);
                            return true;
                        case EQuestionType.QueryFirstOrDefaultQuestion:
                            PrintAnswerInterpretation(_questionType, false);
                            return true;
                        default: return false;
                    }
                case '3':
                    switch (_questionType)
                    {
                        case EQuestionType.FastestORM:
                            PrintAnswerInterpretation(_questionType, false);
                            return true;
                        case EQuestionType.QueryFirstOrDefaultQuestion:
                            PrintAnswerInterpretation(_questionType, true);
                            return true;
                        default: return false;
                    }

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

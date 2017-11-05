using Common.Enum;
using Common.Properties;
using System;
using System.Collections.Generic;

namespace Common.Utility
{
    public class PointsProcessor : IDisposable
    {
        public void Dispose()
        {
            Settings.Default.Save();
        }

        public void ProcessPoints(EQuestionType questionType, bool result)
        {
            switch (questionType)
            {
                case EQuestionType.QueryFirstQuestion:
                    Settings.Default.QueryFirstQuestion = result;
                    Settings.Default.QueryFirstQuestionTry++;
                    break;
                case EQuestionType.FastestORM:
                    Settings.Default.FastestORM = result;
                    Settings.Default.FastestORMTry++;
                    break;
                case EQuestionType.QueryFirstOrDefaultQuestion:
                    Settings.Default.QueryFirstOrDefaultQuestion = result;
                    Settings.Default.QueryFirstOrDefaultQuestionTry++;
                    break;
                case EQuestionType.QuerySingleQuestion:
                    Settings.Default.QuerySingleQuestion = result;
                    Settings.Default.QuerySingleQuestionTry++;
                    break;
            }
            Settings.Default.Save();
            UpdatePointsState();
            Settings.Default.Save();
        }

        private void UpdatePointsState()
        {
            IList<Point> pointsTable = new List<Point>();
            pointsTable.Add(new Point { LastAnswer = Settings.Default.QueryFirstQuestion, QuestionType = EQuestionType.QueryFirstQuestion, TryCount = Settings.Default.QueryFirstQuestionTry });
            pointsTable.Add(new Point { LastAnswer = Settings.Default.FastestORM, QuestionType = EQuestionType.FastestORM, TryCount = Settings.Default.FastestORMTry });
            pointsTable.Add(new Point { LastAnswer = Settings.Default.QueryFirstOrDefaultQuestion, QuestionType = EQuestionType.QueryFirstOrDefaultQuestion, TryCount = Settings.Default.QueryFirstOrDefaultQuestionTry });
            pointsTable.Add(new Point { LastAnswer = Settings.Default.QuerySingleQuestion, QuestionType = EQuestionType.QuerySingleQuestion, TryCount = Settings.Default.QuerySingleQuestionTry });

            double endPoints = 0.0;

            foreach (var point in pointsTable)
            {
                if (point.TryCount == 0) endPoints = 0.0;
                else endPoints += (point.LastAnswer) ? 1.0 / point.TryCount : 0.0;
            }

            Settings.Default.PointsState = endPoints;
        }

        public void PrintPointsState() =>
            Console.WriteLine($"U've got: {Settings.Default.PointsState.ToString("N2")} points");

        public void ReInitializeTable()
        {
            Settings.Default.QueryFirstQuestion = false;
            Settings.Default.QueryFirstQuestionTry = 0;
            Settings.Default.FastestORM = false;
            Settings.Default.FastestORMTry = 0;
            Settings.Default.QueryFirstOrDefaultQuestion = false;
            Settings.Default.QueryFirstOrDefaultQuestionTry = 0;
            Settings.Default.PointsState = 0.0;
        }
    }
}

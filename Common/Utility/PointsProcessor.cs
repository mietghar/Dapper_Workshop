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

            double endPoints = 0.0;

            foreach (var point in pointsTable)
                endPoints += (point.LastAnswer) ? 1.0 / point.TryCount : 0.0;

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
            Settings.Default.PointsState = 0.0;
        }
    }
}

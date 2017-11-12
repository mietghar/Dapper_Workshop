using Common.Enum;
using Common.Properties;
using System;
using System.Collections.Generic;

namespace Common.Utility
{
    public class PointsProcessor : IDisposable
    {
        private List<Point> _pointsTable = new List<Point>();
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
                case EQuestionType.QuerySingleOrDefaultQuestion:
                    Settings.Default.QuerySingleOrDefaultQuestion = result;
                    Settings.Default.QuerySingleOrDefaultQuestionTry++;
                    break;
            }
            Settings.Default.Save();
            UpdatePointsState();
            Settings.Default.Save();
        }

        private void PopulatePointsTable()
        {
            _pointsTable.Clear();
            _pointsTable.Add(new Point { LastAnswer = Settings.Default.QueryFirstQuestion, QuestionType = EQuestionType.QueryFirstQuestion, TryCount = Settings.Default.QueryFirstQuestionTry });
            _pointsTable.Add(new Point { LastAnswer = Settings.Default.FastestORM, QuestionType = EQuestionType.FastestORM, TryCount = Settings.Default.FastestORMTry });
            _pointsTable.Add(new Point { LastAnswer = Settings.Default.QueryFirstOrDefaultQuestion, QuestionType = EQuestionType.QueryFirstOrDefaultQuestion, TryCount = Settings.Default.QueryFirstOrDefaultQuestionTry });
            _pointsTable.Add(new Point { LastAnswer = Settings.Default.QuerySingleQuestion, QuestionType = EQuestionType.QuerySingleQuestion, TryCount = Settings.Default.QuerySingleQuestionTry });
            _pointsTable.Add(new Point { LastAnswer = Settings.Default.QuerySingleOrDefaultQuestion, QuestionType = EQuestionType.QuerySingleOrDefaultQuestion, TryCount = Settings.Default.QuerySingleOrDefaultQuestionTry });
        }

        private void UpdatePointsState()
        {
            PopulatePointsTable();

            double endPoints = 0.0;

            foreach (var point in _pointsTable)
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
            Settings.Default.QuerySingleQuestion = false;
            Settings.Default.QuerySingleQuestionTry = 0;
            Settings.Default.QuerySingleOrDefaultQuestion = false;
            Settings.Default.QuerySingleOrDefaultQuestionTry = 0;
            Settings.Default.PointsState = 0.0;
        }
    }
}

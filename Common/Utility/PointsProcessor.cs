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
            }
            Settings.Default.Save();
            UpdatePointsState();
            Settings.Default.Save();
        }

        private void UpdatePointsState()
        {
            Dictionary<bool, int> pointsTable = new Dictionary<bool, int>();
            pointsTable.Add(Settings.Default.QueryFirstQuestion, Settings.Default.QueryFirstQuestionTry);

            double endPoints = 0.0;

            foreach(KeyValuePair<bool, int> record in pointsTable)
                endPoints += (record.Key) ? 1.0 / record.Value : 0.0;

            Settings.Default.PointsState = endPoints;
        }

        public void PrintPointsState() =>
            Console.WriteLine($"U've got: {Settings.Default.PointsState.ToString("N2")} points");

        public void ReInitializeTable()
        {
            Settings.Default.QueryFirstQuestion = false;
            Settings.Default.QueryFirstQuestionTry = 0;
            Settings.Default.PointsState = 0.0;
        }
    }
}

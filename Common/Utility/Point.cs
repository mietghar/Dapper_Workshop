using Common.Enum;

namespace Common.Utility
{
    public class Point
    {
        public EQuestionType QuestionType { get; set; }
        public int TryCount { get; set; }
        public bool LastAnswer { get; set; }
    }
}

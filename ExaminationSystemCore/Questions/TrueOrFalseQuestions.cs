
namespace ExaminationSystemCore.Questions;

using ExaminationSystemCore.Answers;
public class TrueOrFalseQuestions : Question
{
    #region ctor
    public TrueOrFalseQuestions(string headerOfQuestion, string bodyOfQuestion, int mark, List<Answers> answers, int rightAnswerID) : base(headerOfQuestion, bodyOfQuestion, mark, answers, rightAnswerID)
    {
    }
    #endregion




}

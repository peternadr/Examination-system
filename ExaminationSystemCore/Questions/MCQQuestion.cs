
namespace ExaminationSystemCore.Questions;
using ExaminationSystemCore.Answers;

public class MCQQuestion : Question
{

    #region ctor
    public MCQQuestion(string headerOfQuestion, string bodyOfQuestion, int mark, List<Answers> answers, int rightAnswerID) : base(headerOfQuestion, bodyOfQuestion, mark, answers, rightAnswerID)
    {
    } 
    #endregion
}

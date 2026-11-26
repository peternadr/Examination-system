namespace ExaminationSystemCore.Answers;

public class Answers
{
    public string AnswerText { get; }
    public int AnswerId { get; }

    public Answers(string answerText, int answerId)
    {
        AnswerText = answerText;
        AnswerId = answerId;
    }

    public override string ToString()
    {
        return $"{AnswerText}";
    }

}

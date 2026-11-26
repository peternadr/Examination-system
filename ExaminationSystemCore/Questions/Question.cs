namespace ExaminationSystemCore.Questions;
using ExaminationSystemCore.Answers;

public class Question
{
    #region properties
    public string HeaderOfQuestion { get; }
    public string BodyOfQuestion { get; }
    public int Mark { get; }
    public List<Answers> Answers { get; }
    public int RightAnswerID { get; } 
    

    #endregion

    #region ctor
    public Question(string headerOfQuestion, string bodyOfQuestion, int mark, List<Answers> answers, int rightAnswerID)
    {
        HeaderOfQuestion = headerOfQuestion;
        BodyOfQuestion = bodyOfQuestion;
        Mark = mark;
        Answers = answers;
        RightAnswerID = rightAnswerID;
    }
    #endregion

    #region Methods

    public void DisplayQuestion()
    {
        Console.WriteLine(BodyOfQuestion);
        Console.Write(HeaderOfQuestion);
        Console.WriteLine($"  Mark: {Mark}");
        for (int j = 0; j < Answers.Count; j++)
        {
            Console.WriteLine($"{j + 1}- {Answers[j].AnswerText}");
        }
    }


    #endregion
}

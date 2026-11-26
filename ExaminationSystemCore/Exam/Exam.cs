namespace ExaminationSystemCore.Exam;
using ExaminationSystemCore.Questions;
using System.Diagnostics;

public abstract class Exam
{
	#region Properties
	public int TimeOfExam { get; }
	public int NumberOfQuestions { get; }
	public List<Question> Questions { get; }
    public List<int>UserAnswers { get; set; }
    public int UserGrade { get; set; }
    public int TotalMarks { get; set; }
    public Stopwatch examTime = new Stopwatch();

    #endregion

    #region ctor
    protected Exam(int timeOfExam, int numberOfQuestions, List<Question>questions)
    {
        TimeOfExam = timeOfExam;
        NumberOfQuestions = numberOfQuestions;
        Questions = questions;
        UserGrade = 0;
        UserAnswers = new List<int>();
    }

    #endregion

    #region Methods
    public abstract void CalculateTotalMarks();

    public abstract void DisplayExam();

    public abstract void DisplayExamResultInfo();

    #endregion

}

namespace ExaminationSystemCore.Subject;
using ExaminationSystemCore.Exam;
using ExaminationSystemCore.Questions;
using ExaminationSystemCore.Answers;
public class Subject
{
	#region properties
	public int SubjectID { get; }
	public string SubjectName { get; }
    public Exam Exam { get; private set; } = default!;

    #endregion

    #region ctor
    public Subject(int subjectID, string subjectName)
    {
        SubjectID = subjectID;
        SubjectName = subjectName;
    }
    #endregion

    #region Methods

    public void CreateExam(Exam exam)
    {
        if (exam is null)
        {
            Console.WriteLine("No exam has been created yet!");
            return;
        }

        exam.DisplayExam();
        Console.WriteLine();
        Console.Clear();
        exam.CalculateTotalMarks();

        exam.DisplayExamResultInfo();

    }

    #endregion

}

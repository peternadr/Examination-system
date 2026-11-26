using ExaminationSystemCore.Questions;
using ExaminationSystemCore.Utilities;

namespace ExaminationSystemCore.Exam;

public class FinalExam : Exam
{
    #region ctor
    public FinalExam(int timeOfExam, int numberOfQuestions, List<Question> questions) : base(timeOfExam, numberOfQuestions, questions)
    {
    } 
    #endregion

    #region Methods
    public override void CalculateTotalMarks()
    {
        int totalMarks = 0;
        //check if the user solve the Question Correctly
        for (int i = 0; i < Questions.Count; i++)
        {
            var question = Questions[i];
            totalMarks += question.Mark;

            if (UserAnswers[i] == question.RightAnswerID)
            {
                UserGrade += question.Mark;
            }
        }
        TotalMarks = totalMarks;
    }

    public override void DisplayExam()
    {
        examTime.Start();
        Console.WriteLine("Final Exam");
        for (int i = 0; i < NumberOfQuestions; i++)
        {
            int userAnswer;
            bool flag;
            var question = Questions[i];
            Console.Write($"Question {i + 1}: ");
            question.DisplayQuestion();
            do
            {
                Console.WriteLine("Enter Your Answer Id: ");
                flag = int.TryParse(Console.ReadLine(), out userAnswer);
            }
            while (!flag);
            UserAnswers.Add(userAnswer);
            Console.WriteLine();
        }
        examTime.Stop();
    }

    public override void DisplayExamResultInfo()
    {
        // Display the user's questions and the total marks for the exam
        Console.WriteLine("Final Exam Result:");
        for (int i = 0; i < Questions.Count; i++)
        {
            var question = Questions[i];
            Console.WriteLine($"Question {i + 1}: {question.BodyOfQuestion}");
            Console.WriteLine($"Your Answer => {question.Answers[UserAnswers[i] - 1].ToString()}");
            Console.WriteLine($"Correct Answer => {question.Answers[(question.RightAnswerID) - 1].ToString()}");
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine($"Your Grade Is: {UserGrade} From {TotalMarks}");
        Console.WriteLine($"Time: {examTime.Elapsed}");
        Console.WriteLine("Thank You");
    } 

    #endregion
}

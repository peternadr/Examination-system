namespace Examination_system;

using ExaminationSystemCore.Exam;
using ExaminationSystemCore.Questions;
using ExaminationSystemCore.Answers;
using ExaminationSystemCore.Subject;
using ExaminationSystemCore.Utilities;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        //creat Exam reference
        Exam exam;

        //Get the exam type from the user
        int ExamType = Helper.GetValidIntegerInput("Enter The Type Of Exam (1 for Practical , 2 for Final): ", 1, 2);

        // get the time of exam from the user
        int TimeOfExam = Helper.GetValidIntegerInput("Please enter the time for the exam (30 to 180 Minutes): ", 30, 180);

        // get the number of the questions from the user
        int NumberOfQuestions = Helper.GetValidIntegerInput("Please enter the number of the questions: ", 1, int.MaxValue);

        Console.Clear();

        // Create a list to hold the questions
        List<Question> questions = new List<Question>();


        string questionBody;
        int questionMarks;
        string answerBody;
        int rightAnswerID;

        // create a practical exam or final exam based on the user's input

        #region Practical Exam

        if (ExamType == 1)
        {

            // Loop through the number of questions and get the question details from the user
            for (int i = 1; i <= NumberOfQuestions; i++)
            {
                //Get the body of the question from the user
                questionBody = Helper.GetNonEmptyStringInput("Please enter the body of question: ");

                //Get the marks of the question from the user 
                questionMarks = Helper.GetValidIntegerInput("Please enter the marks for the question: ", 1, int.MaxValue);

                // Get the answers for the question from the user
                Console.WriteLine("Choices of the question: ");

                // Create a list to hold the Answers
                List<Answers> answers = new List<Answers>();

                for (int j = 1; j <= 4; j++)
                {
                    //get the answer body from the user
                    answerBody = Helper.GetNonEmptyStringInput($"Please enter choice number {j}: ");
                    answers.Add(new Answers(answerBody, j));
                }

                // Get the right answer ID from the user
                rightAnswerID = Helper.GetValidIntegerInput("Please enter the ID of the correct answer (1 to 4): ", 1, 4);

                // Add the question to the list of questions
                questions.Add(new MCQQuestion("MCQ Question", questionBody, questionMarks, answers, rightAnswerID));
                Console.Clear();

            } 
            exam = new PracticalExam(TimeOfExam, NumberOfQuestions, questions);
            
        }

        #endregion

        #region Final Exam

        else
        {
            //Loop through the number of questions and get the question details from the user
            for (int i = 1; i <= NumberOfQuestions; i++)
            {
                // get the type of the question from the user
                int QuestionType = Helper.GetValidIntegerInput("Please enter the type of question (1 for MCQ, 2 for True/False): ", 1, 2);

                #region MCQ Question
                if (QuestionType == 1)
                {
                    //Get the body of the question from the user
                    questionBody = Helper.GetNonEmptyStringInput("Please enter the body of question: ");

                    //Get the marks of the question from the user 
                    questionMarks = Helper.GetValidIntegerInput("Please enter the marks for the question: ", 1, int.MaxValue);

                    // Create a list to hold the Answers
                    List<Answers> answers = new List<Answers>();

                    // Get the answers for the question from the user
                    Console.WriteLine("Choices of the question: ");
                    for (int j = 1; j <= 4; j++)
                    {
                        //get the answer body from the user
                        answerBody = Helper.GetNonEmptyStringInput($"Please enter choice number {j}: ");
                        answers.Add(new Answers(answerBody, j));
                    }

                    // Get the right answer ID from the user
                    rightAnswerID = Helper.GetValidIntegerInput("Please enter the ID of the correct answer (1 to 4): ", 1, 4);

                    // Add the question to the list of questions
                    questions.Add(new MCQQuestion("MCQ Question", questionBody, questionMarks, answers, rightAnswerID));
                }

                #endregion

                #region TrueOrFalse Question

                else if (QuestionType == 2)
                {
                    //Get the body of the question from the user
                    questionBody = Helper.GetNonEmptyStringInput("Please enter the body of question: ");

                    //Get the marks of the question from the user 
                    questionMarks = Helper.GetValidIntegerInput("Please enter the marks for the question: ", 1, int.MaxValue);

                    //get the right answer of the question from the user
                    rightAnswerID = Helper.GetValidIntegerInput("Please enter the ID of the correct answer(1 for True, 2 for False): ", 1, 2);

                    //Create a list of answers for the True/ False question
                    List<Answers> answers = new List<Answers>
                    {
                        new Answers("True", 1),
                        new Answers("False", 2)
                    };

                    // Create a new question and add it to the list
                    Question question = new TrueOrFalseQuestions("True/False Question", questionBody, questionMarks, answers, rightAnswerID);
                    questions.Add(question);
                }


                #endregion

                Console.Clear();
            }
            exam = new FinalExam(TimeOfExam, NumberOfQuestions, questions);
        }


        #endregion

        //creat a subject 
        Subject subject = new Subject(2, "OOP");

        //ask user to start an exam
        string StartExam;
        do
        {
            Console.Write("Do You Want To Start Exam (Y | N): ");
            StartExam = Console.ReadLine().ToUpper();

            if (StartExam != "Y" && StartExam != "N")
            {
                Console.WriteLine("Invalid input! Please enter Y or N.");
            }

        } while (StartExam != "Y" && StartExam != "N");
        Console.Clear();

        // if user Want to start
        if (StartExam == "Y")
        {
            subject.CreateExam(exam);
        }


        // if user do not want to start
        else
        {
            Console.WriteLine("Thank you");
        }

    }
}

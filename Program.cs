using Examination_System.Exams;
using Examination_System.Questions;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 1️⃣ Create Subject
                Subject subject = new Subject("Programming Fundamentals");

                Student s1 = new Student(1, "Mariam");
                Student s2 = new Student(2, "Ali");
                Student s3 = new Student(3, "Sara");

                subject.Enroll(s1);
                subject.Enroll(s2);
                subject.Enroll(s3);

                //  True/False Question
                Answer a1 = new Answer(1, "True");
                Answer a2 = new Answer(2, "False");
                AnswerList tfList = new AnswerList();
                tfList.Add(a1);
                tfList.Add(a2);
                AnswerList TFCorrectAnswers = new AnswerList();
                TFCorrectAnswers.Add(a1);
                TrueFalseQuestion tfQuestion = new TrueFalseQuestion(
                 "Q1",
                 "C# is strongly typed?",
                 5,
                 tfList,
                 TFCorrectAnswers
             );
                //  ChooseOne Question
                Answer a3 = new Answer(1, "C#");
                Answer a4 = new Answer(2, "HTML");
                Answer a5 = new Answer(3, "Python");
                Answer a6 = new Answer(4, "CSS");


                AnswerList chooseOneList = new AnswerList();
                chooseOneList.Add(a3);
                chooseOneList.Add(a4);
                chooseOneList.Add(a5);
                AnswerList chooseOneListCorrectAnswers = new AnswerList();
                chooseOneListCorrectAnswers.Add(a3);
                ChooseOneQuestion chooseOneQuestion = new ChooseOneQuestion(
                    "Q2",
                    "Which language is developed by Microsoft?",
                    5,
                    chooseOneList,
                    chooseOneListCorrectAnswers

                );

                // Choose All Question
                AnswerList chooseAllList = new AnswerList();
                chooseAllList.Add(a3);
                chooseAllList.Add(a4);
                chooseAllList.Add(a5);
                chooseAllList.Add(a6);


                AnswerList chooseAllQuestion_CorrectAnswers = new AnswerList();
                chooseAllQuestion_CorrectAnswers.Add(a3);
                chooseAllQuestion_CorrectAnswers.Add(a5);

                ChooseAllQuestion chooseAllQuestion = new ChooseAllQuestion(
                    "Q3",
                    "Which of the following are programming languages?",
                    5,
                    chooseAllList,
                    chooseAllQuestion_CorrectAnswers
                );
                //-----------------------------------
                Question[] questions = { tfQuestion, chooseOneQuestion, chooseAllQuestion };

                PracticeExam practiceExam = new PracticeExam(30, questions, subject);
                FinalExam finalExam = new FinalExam(25, questions, subject);

                Console.WriteLine("===== Testing Generic Repository  =====\n");
                Repository<Exam> examRepo = new Repository<Exam>();

                examRepo.Add(practiceExam);
                examRepo.Add(finalExam);

                examRepo.Sort();

                Exam[] exams = examRepo.GetAll();
                for(int i=0; i<exams.Length; i++)
                {
                    Console.WriteLine(exams[i]);
                }
                Console.WriteLine("======================================\n");

                Exam selectedExam;
                int choice;
                while (true)
                {
                    Console.WriteLine("Select Exam Type:");
                    Console.WriteLine("1 - Practice Exam");
                    Console.WriteLine("2 - Final Exam");
                    Console.Write("Enter choice: ");

                    string? input = Console.ReadLine();

                    if (!int.TryParse(input, out choice))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        continue;
                    }

                    if (choice == 1)
                    {
                        selectedExam = practiceExam;
                        break;
                    }
                    else if (choice == 2)
                    {
                        selectedExam = finalExam;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Enter 1 or 2.");
                    }
                }


                Console.WriteLine("\nStarting Exam...\n");

                subject.NotifyStudents(selectedExam);

                selectedExam.Start();
                foreach (Question q in selectedExam.Questions)
                {
                    Console.WriteLine("--------------------------");
                    q.Display();

                    if (q is ChooseAllQuestion)
                    {
                        AnswerList selected = new AnswerList(0);

                        while (true) 
                        {
                            Console.WriteLine("Enter answer IDs separated by comma:");
                            string input = Console.ReadLine()?.Trim() ?? "";

                            if (string.IsNullOrWhiteSpace(input))
                            {
                                Console.WriteLine("Input cannot be empty.");
                                continue;
                            }

                            string[] parts = input.Split(',');
                            bool valid = true;

                            selected = new AnswerList(parts.Length);

                            foreach (var part in parts)
                            {
                                if (!int.TryParse(part.Trim(), out int id))
                                {
                                    Console.WriteLine($"'{part}' is not a valid number.");
                                    valid = false;
                                    break;
                                }

                                Answer ans = q.Answers.GetById(id);

                                if (ans.Id == -1) 
                                {
                                    Console.WriteLine($"Answer ID {id} does not exist.");
                                    valid = false;
                                    break;
                                }

                                selected.Add(ans);
                            }

                            if (valid) break; // exit loop only if all input is valid
                        }

                        selectedExam.QuestionAnswerDictionary[q] = selected;
                    }
                    else
                    {
                        AnswerList studentAnswer = new AnswerList(1);

                        while (true)
                        {
                            Console.WriteLine("Enter Answer Id:");

                            string input = Console.ReadLine()?.Trim() ?? "";

                            if (!int.TryParse(input, out int id))
                            {
                                Console.WriteLine("Invalid input. Please enter a number.");
                                continue;
                            }

                            Answer ans = q.Answers.GetById(id);
                            if (ans == null)
                            {
                                Console.WriteLine($"Answer ID {id} does not exist.");
                                continue;
                            }

                            studentAnswer.Add(ans);
                            break;
                        }

                        selectedExam.QuestionAnswerDictionary[q] = studentAnswer;
                    }
                }

                // Finish exam
                selectedExam.Finish();

                Console.WriteLine("\n===== Exam Results =====\n");

                selectedExam.ShowExam();



                // Logging Test
                QuestionList qList = new QuestionList("TestQuestionsLog.txt");

                qList.Add(tfQuestion);
                qList.Add(chooseOneQuestion);
                qList.Add(chooseAllQuestion);

                Console.WriteLine("\nQuestions logged to file successfully.");

                // Saving ExamResult To File Test

                string resultFile = selectedExam.Subject.Name + "_Results.txt";
                selectedExam.SaveResultsToFile(resultFile);
                Console.WriteLine($"Results saved to {resultFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

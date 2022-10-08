
class Program
{
    static string? course;
    static string? student;
    static double[,]? allStudentScores = new double[2, 2];
    static double? specialProjectGrade = 0;

    static void Main(string[] args)
    {
        ConsoleKeyInfo c1 = new ConsoleKeyInfo();
        do
        {
            //Console.CursorVisible = true;
            Console.WriteLine();
            Console.WriteLine("STUDENT GRADING PROGRAM");
            Console.WriteLine();
            Console.WriteLine("1. Enter the name of the course");
            Console.WriteLine("2. Enter student information");
            Console.WriteLine("3. Enter exam grades");
            Console.WriteLine("4. Enter Special Project grade");
            Console.WriteLine("5. Calculate final grade");
            Console.WriteLine("6. Exit application");
            Console.WriteLine();
            Console.Write("Enter menu selection: ");

            //Console.CursorVisible = false;
            while (Console.KeyAvailable == false)
            {
                Thread.Sleep(50);
                c1 = Console.ReadKey();
                string keyPressed = c1.KeyChar.ToString();

                if (keyPressed == "1")
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("STUDENT GRADING PROGRAM");
                    Console.WriteLine();
                    Console.Write("Enter course name: ");
                    course = Console.ReadLine();
                    Console.Clear();
                    break;
                }
                else if (keyPressed == "2")
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("STUDENT GRADING PROGRAM");
                    Console.WriteLine();
                    Console.Write("Enter student name: ");
                    student = Console.ReadLine();
                    Console.Clear();
                    break;
                }
                else if (keyPressed == "3")
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("STUDENT GRADING PROGRAM");
                    Console.WriteLine();
                    Console.WriteLine("Input Student Scores");
                    Console.WriteLine();

                    try
                    {
                        for (int i = 0; i < allStudentScores.GetLength(0); i++)
                        {
                            for (int j = 0; j < allStudentScores.GetLength(1); j++)
                            {
                                Console.Write("Enter a student test score: ");
                                double.TryParse(Console.ReadLine()?.ToString(), out double testScore);
                                Console.WriteLine("You entered: " + testScore);
                                Console.WriteLine();

                                allStudentScores[i, j] = testScore;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception: " + ex);
                    }
                    finally
                    {
                        Console.Clear();
                        Console.WriteLine();
                    }
                    break;
                }
                else if (keyPressed == "4")
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("STUDENT GRADING PROGRAM");
                    Console.WriteLine();
                    Console.Write("Enter Special Project grade: ");
                    double.TryParse(Console.ReadLine()?.ToString(), out double result);
                    specialProjectGrade = result;
                    Console.Clear();
                    break;

                }
                else if (keyPressed == "5")
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("STUDENT GRADING PROGRAM");
                    Console.WriteLine();
                    Console.WriteLine("Overall grade point average");
                    Console.WriteLine();
                    double testScores = 0;

                    int idx = 0;
                    foreach (var score in allStudentScores)
                    {
                        // Each test score weighted 20% of grade for a total of 80%.
                        ++idx;
                        testScores += score * 0.20;
                    }

                    Console.WriteLine("Course: " + course);
                    Console.WriteLine("Student: " + student);
                    Console.WriteLine();
                    // The special project score is also weighted as 20% of the student grade.
                    // The combined test scores are 80% and special project is 20%, totaling 100%.
                    var weightedSpecialProjScore = specialProjectGrade * 0.20;
                    double? finalGrade = weightedSpecialProjScore + testScores;
                    Console.WriteLine("The overall course grade for this student is: {0}", String.Format("{0:0.00}", finalGrade));
                    Console.WriteLine("This includes the Special Project, weighted at 20% of the overall course grade");

                    ConsoleKeyInfo c2 = new ConsoleKeyInfo();
                    do
                    {
                        Console.WriteLine("\nPress x to go back to the menu.");
                        Console.CursorVisible = false;
                        while (Console.KeyAvailable == false)
                        {
                            Thread.Sleep(50);
                            c2 = Console.ReadKey(true);
                            //Console.WriteLine("You pressed the '{0}' key.", c.Key);
                            keyPressed = c2.Key.ToString().ToLower();

                            if (keyPressed == "x")
                            {
                                Console.Clear();
                                break;
                            }
                        }

                    } while (c2.Key != ConsoleKey.X);
                    break;
                }
                else if (keyPressed == "6")
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }
        } while (c1.Key != ConsoleKey.X);
    }
}
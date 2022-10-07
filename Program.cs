
class Program
{
    static string? course;
    static string? student;
    static double[,]? allStudentScores = new double[2, 2];
    static double? specialProjectGrade = 0;

    static void Main(string[] args)
    {
        ShowCourse();
    }

    public static void ShowCourse()
    {
        Console.CursorVisible = true;
        Console.WriteLine();
        Console.WriteLine("STUDENT GRADING PROGRAM");
        Console.WriteLine();
        Console.WriteLine("1. Enter the name of the course");
        Console.WriteLine("2. Enter student information");
        Console.WriteLine("3. Enter and calculate grades");
        Console.WriteLine("4. Exit application");
        Console.WriteLine();
        Console.Write("Enter menu selection: ");

        string? menuSelection = Console.ReadLine();
        switch (menuSelection)
        {
            case "1":
                Console.Clear();
                GetCourseName();
                break;
            case "2":
                Console.Clear();
                GetStudentInfo();
                break;
            case "3":
                Console.Clear();
                ShowMenu();
                break;
            case "4":
                Console.Clear();
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Console.Beep();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("You entered an invalid menu selection");
                Console.BackgroundColor = ConsoleColor.Black;
                ShowCourse();
                break;
        }
    }

    private static void GetCourseName()
    {
        Console.WriteLine();
        Console.WriteLine("STUDENT GRADING PROGRAM");
        Console.WriteLine();
        Console.Write("Enter course name: ");
        course = Console.ReadLine();
        Console.Clear();
        ShowCourse();
    }

    private static void GetStudentInfo()
    {
        Console.WriteLine();
        Console.WriteLine("STUDENT GRADING PROGRAM");
        Console.WriteLine();
        Console.Write("Enter student name: ");
        student = Console.ReadLine();
        Console.Clear();
        ShowCourse();
    }

    public static void ShowMenu()
    {
        Console.CursorVisible = true;
        Console.WriteLine();
        Console.WriteLine("STUDENT GRADING PROGRAM");
        Console.WriteLine();
        Console.WriteLine("Course: " + course);
        Console.WriteLine("Student: " + student);
        Console.WriteLine();
        Console.WriteLine("1. Enter exam grades");
        Console.WriteLine("2. Enter special project grade");
        Console.WriteLine("3. Show all grades for student");
        Console.WriteLine("4. Show student special project score");
        Console.WriteLine("5. Show student average grade on exams");
        Console.WriteLine("6. Show overall course grade (includes spacial project)");
        Console.WriteLine("7. Exit");
        Console.WriteLine();
        Console.Write("Enter menu selection: ");

        string? menuSelection = Console.ReadLine();
        switch (menuSelection)
        {
            case "1":
                Console.Clear();
                GetStudentScores();
                break;
            case "2":
                Console.Clear();
                GetSpecialProjectGrade();
                break;
            case "3":
                Console.Clear();
                ShowAllStudentGrades();
                break;
            case "4":
                Console.Clear();
                ShowSpecialProjectGrade();
                break;
            case "5":
                Console.Clear();
                CalculateTestScores();
                break;
            case "6":
                Console.Clear();
                CalculateAllScores();
                break;
            case "7":
                Console.Clear();
                Console.WriteLine("You selected exit");
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Console.Beep();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("You entered an invalid menu selection");
                Console.BackgroundColor = ConsoleColor.Black;
                ShowMenu();
                break;
        }
    }

    private static void ShowAllStudentGrades()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("STUDENT GRADING PROGRAM");
        Console.WriteLine();
        Console.WriteLine("All Grades");
        Console.WriteLine();
        int examCount = 0;
        for (int i = 0; i < allStudentScores.GetLength(0); i++)
        {
            for (int j = 0; j < allStudentScores.GetLength(1); j++)
            {
                Console.Write("Exam {0}: ", ++examCount);
                Console.WriteLine(allStudentScores[i, j]);
            }
        }
        Console.WriteLine();
        Console.WriteLine("Special project grade: {0} ", specialProjectGrade);
        Console.WriteLine();
        //Console.Clear();
        //ShowMenu();

        ConsoleKeyInfo c = new ConsoleKeyInfo();
        do
        {
            Console.WriteLine("\nPress x to go back to the menu.");
            Console.CursorVisible = false;
            while (Console.KeyAvailable == false)
            {
                Thread.Sleep(50);
                c = Console.ReadKey(true);
                //Console.WriteLine("You pressed the '{0}' key.", c.Key);
                string keyPressed = c.Key.ToString().ToLower();

                if (keyPressed == "x")
                {
                    Console.Clear();
                    ShowMenu();
                }
            }

        } while (c.Key != ConsoleKey.X);
    }

    private static void ShowSpecialProjectGrade()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("STUDENT GRADING PROGRAM");
        Console.WriteLine();
        Console.WriteLine("Student Special Project");
        Console.WriteLine("This score accounts for 20 percent of the student grade.");
        Console.WriteLine();
        Console.WriteLine("Special project grade: " + specialProjectGrade);
        Console.WriteLine();
        ConsoleKeyInfo c = new ConsoleKeyInfo();
        do
        {
            Console.WriteLine("\nPress x to go back to the menu.");
            Console.CursorVisible = false;
            while (Console.KeyAvailable == false)
            {
                Thread.Sleep(50);
                c = Console.ReadKey(true);
                //Console.WriteLine("You pressed the '{0}' key.", c.Key);
                string keyPressed = c.Key.ToString().ToLower();

                if (keyPressed == "x")
                {
                    Console.Clear();
                    ShowMenu();
                }
            }

        } while (c.Key != ConsoleKey.X);
    }

    private static void GetStudentScores()
    {
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
            ShowMenu();
        }
    }

    private static void CalculateTestScores()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("STUDENT GRADING PROGRAM");
        Console.WriteLine();
        Console.WriteLine("Grade Point Average");
        Console.WriteLine();

        double result = 0;
        int idx = 0;
        foreach (var score in allStudentScores)
        {
            ++idx;
            result += score;
        }

        double examGrade = result / idx;
        Console.WriteLine("The average grade for all exams for this student is: {0}", String.Format("{0:0.00}", examGrade));
        Console.WriteLine("This score does not include the weighted average for the students Special Project");

        ConsoleKeyInfo c = new ConsoleKeyInfo();
        do
        {
            Console.WriteLine("\nPress x to go back to the menu.");
            Console.CursorVisible = false;
            while (Console.KeyAvailable == false)
            {
                Thread.Sleep(50);
                c = Console.ReadKey(true);
                string keyPressed = c.Key.ToString().ToLower();

                if (keyPressed == "x")
                {
                    Console.Clear();
                    ShowMenu();
                }
            }

        } while (c.Key != ConsoleKey.X);
    }

    private static void CalculateAllScores()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("STUDENT GRADING PROGRAM");
        Console.WriteLine();
        Console.WriteLine("Grade point average");
        Console.WriteLine();
        double testScores = 0;

        int idx = 0;
        foreach (var score in allStudentScores)
        {
            // Each test score weighted 20% of grade for a total of 80%.
            ++idx;
            testScores += score * 0.20;
        }

        // The special project score is also weighted as 20% of the student grade.
        // The combined test scores are 80% and special project is 20%, totaling 100%.
        var weightedSpecialProjScore = specialProjectGrade * 0.20;
        double? finalGrade = weightedSpecialProjScore + testScores;

        Console.WriteLine("The overall course grade for this student is: {0}", String.Format("{0:0.00}", finalGrade));
        Console.WriteLine("This includes the Special Project, weighted at 20% of the overall course grade");

        ConsoleKeyInfo c = new ConsoleKeyInfo();
        do
        {
            Console.WriteLine("\nPress x to go back to the menu.");
            Console.CursorVisible = false;
            while (Console.KeyAvailable == false)
            {
                Thread.Sleep(50);
                c = Console.ReadKey(true);
                //Console.WriteLine("You pressed the '{0}' key.", c.Key);
                string keyPressed = c.Key.ToString().ToLower();

                if (keyPressed == "x")
                {
                    Console.Clear();
                    ShowMenu();
                }
            }

        } while (c.Key != ConsoleKey.X);
    }

    private static void GetSpecialProjectGrade()
    {
        Console.WriteLine();
        Console.WriteLine("STUDENT GRADING PROGRAM");
        Console.WriteLine();
        Console.WriteLine("Input Special project grade");
        Console.WriteLine();
        Console.Write("Enter special project score: ");
        double.TryParse(Console.ReadLine()?.ToString(), out double result);
        specialProjectGrade = result;
        Console.Clear();
        ShowMenu();
        Console.WriteLine();
    }
}
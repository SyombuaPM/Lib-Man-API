using StudentMarksProject;



internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Student Marks");
        Console.WriteLine("---------------------\n");


        StudentMarks[] students = CaptureStudentDetails();
Array.Sort(students, (x, y) => x.CalculateAverage().CompareTo(y.CalculateAverage()));

        for (int i = 0; i < students.Length; i++)
        {
            students[i].averageMark = students[i].CalculateAverage();
            students[i].grade = students[i].CalculateGrade();
            students[i].DisplayStudentDetails();
        }


    }

    static StudentMarks[] CaptureStudentDetails()
    {
        string studentName;
        int mathsMark;
        int englishMark;
        int scienceMark;
        int noOfStudents = 0;
        StudentMarks[] students = new StudentMarks[10];
        while (noOfStudents < 10)
        {
            Console.WriteLine($"Enter Student {11 - noOfStudents} Name: ");
            studentName = Console.ReadLine();

            Console.WriteLine("Enter Maths Mark: ");
            mathsMark = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter English Mark: ");
            englishMark = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Science Mark: ");
            scienceMark = Convert.ToInt32(Console.ReadLine());

            students[noOfStudents] = new StudentMarks(studentName, mathsMark, englishMark, scienceMark);
            noOfStudents++;
            // Added a return statement
        }

        return students; // Added a default return statement
    }
}
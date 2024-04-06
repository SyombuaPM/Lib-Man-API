using system;
usinng

console.writeline("Creating a student");
console.writeline("---------------------\n");

StudentMarks student1 = new StudentMarks("John", 80, 90, 70);
student1.DisplayStudentDetails();

student1.DisplayAverage();


public class StudentMarks
{
    public string studentName;
    public int mathsMark;
    public int englishMark;
    public int scienceMark;


    public double CalculateAverage()
    {
        return (mathsMark + englishMark + scienceMark) / 3;
    }

    public StudentMarks(string name, int maths, int english, int science)
    {
        studentName = name;
        mathsMark = maths;
        englishMark = english;
        scienceMark = science;
    }

    public void DisplayStudentDetails()
    {
        Console.WriteLine($"\nStudent Name: \t{studentName}\nMaths Mark: \t{mathsMark}\nEnglish Mark: \t{englishMark}\nScience Mark: \t{scienceMark}\n");
        Console.WriteLine("Total Marks: \t" + (mathsMark + englishMark + scienceMark) + "\n");
    }

    public void DisplayAverage()
    {
        Console.WriteLine($"Average Mark: \t{CalculateAverage()}\n");
    }

    public char CalculateGrade()
    {
        double average = CalculateAverage();
        if average >= 90
        {
            return 'A';
        }
        else if average >= 80
        {
            return 'B';
        }
        else if average >= 70
        {
            return 'C';
        }
        else if average >= 60
        {
            return 'D';
        }
        else
        {
            return 'F';
        }
}

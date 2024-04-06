using System;


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

}
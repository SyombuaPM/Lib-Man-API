using System;
namespace StudentMarksProject
{
    public class StudentMarks
    {
        public string studentName;
        public int mathsMark;
        public int englishMark;
        public int scienceMark;
        public double averageMark;
        public char grade;



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

    



        public char CalculateGrade()
        {
            double averageMark = CalculateAverage();

            if (averageMark >= 90)
            {
                return 'A';
            }
            else if (averageMark >= 80)
            {
                return 'B';
            }
            else if (averageMark >= 70)
            {
                return 'C';
            }
            else if (averageMark >= 60)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }



        public void DisplayStudentDetails()
        {
            Console.WriteLine($"\nStudent Name: \t{studentName}\nMaths Mark: \t{mathsMark}\nEnglish Mark: \t{englishMark}\nScience Mark: \t{scienceMark}\n");
            Console.WriteLine("Total Marks: \t" + (mathsMark + englishMark + scienceMark) + "\n");
            Console.WriteLine($"Average Mark: \t{CalculateAverage()}\n");
            Console.WriteLine($"Your Grade is: \t{CalculateGrade()}");

        }
    }

}


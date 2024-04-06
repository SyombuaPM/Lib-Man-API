namespace StudentMarks;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Eng { get; set; }
    public int Mat { get; set; }
    public int Sci { get; set; }
    


    public Student(int id, string name, int eng, int mat, int sci)
    {
        Id = id;
        Name = name;
        Eng = eng;
        Mat = mat;
        Sci = sci;

    }


    public int TotalMarks
    {
        get
        { return Eng + Mat + Sci; }
    }

    public double AverageMarks
    {
        get { return TotalMarks / 3; }
    }

    public char GetGrade
    {
        get
        {
            double avg = AverageMarks;
            if (avg >= 70)
            {
                return 'A';
            }
            else if (avg >= 60)
            {
                return 'B';
            }
            else if (avg >= 50)
            {
                return 'C';
            }
            else if (avg >= 40)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

    }
}

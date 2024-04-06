namespace Employee_VsCode_Chapter7_Classes;

public struct WorkTask
{
    public string description;
    public int hours;


    public void PerformWorkTask()
    {
        Console.WriteLine($"The task {description} has been performed for {hours} hours");
    }

}

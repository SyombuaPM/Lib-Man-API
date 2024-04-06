

using Employee_VsCode_Chapter7_Classes;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Creating an employee");
        Console.WriteLine("---------------------");

        Employee bethany = new Employee("Bethany", "Smith", "bethany@snowball.be", 25.0, new DateTime(1979, 1, 16), EmpType: EmployeeType.Manager);



        bethany.PerformWork(25);

        int minimumBonus = 100;

        int receivedBonus = bethany.CalculateBonus(minimumBonus);
        Console.WriteLine($"The Minimum bonus is: {minimumBonus} and {bethany.firstName} has received bonus of: {receivedBonus}");

        //Employee bethany = new("Bethany", "Smith", "bethany@snowball.be", 25.0, new DateTime(1979, 1, 16)); // this is the same as the line above but with the new c# 9 feature where you dont have to specify the class name

        //Employee employee = new Employee(); // this is the default constructor and cant be called because we have already created a constructor

        bethany.DisplayEmployeeDetails();
        bethany.PerformWork();
        bethany.PerformWork();
        bethany.PerformWork(5);
        bethany.PerformWork();

        // using dot notation can be used to override the value in our object for example
        bethany.firstName = "John";
        bethany.hourlyWage = 10;
        bethany.DisplayEmployeeDetails();
        bethany.PerformWork();
        bethany.PerformWork(12);
        bethany.PerformWork();
        bethany.PerformWork();

        double receivedWageBethany = bethany.ReceiveWage(true);
        Console.WriteLine($"Wage paid (message from program): {receivedWageBethany}");

        Employee george = new("George", "Jones", "george@snowball.be", 30, new DateTime(1984, 3, 28), EmployeeType.Research);
        george.DisplayEmployeeDetails();
        george.PerformWork();
        george.PerformWork();
        george.PerformWork(3);
        george.PerformWork();
        george.PerformWork(8);

        var receivedWageGeorge = george.ReceiveWage(true);

        WorkTask task;
        task.description = "Bake delicious pies";
        task.hours = 3;
        task.PerformWorkTask();
    }
}
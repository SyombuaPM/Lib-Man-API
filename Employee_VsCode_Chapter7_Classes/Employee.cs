namespace Employee_VsCode_Chapter7_Classes;

public class Employee
{
    //if you dont create constructor, c# will create a default constructor for you
    //public Employee()
    //{ }   // this is the default constructor

    public string firstName;
    public string lastName;
    public string email;
    public int numberOfHoursWorked;
    public double wage;
    public double hourlyWage;
    public DateTime dateOfBirth;
    const int minimalHoursWorkedUnit = 1;
    public EmployeeType employeeType;

public Employee(string first, string last, string em,  DateTime bd) : this(first, last, em, 0, bd, EmployeeType.StoreManager)
 {

  }// this keyword is used to call another constructor in the same class and pass the parameters that are required
public Employee(string first, string last, string em, double rate, DateTime bd, EmployeeType EmpType)
    {
        firstName = first;
        lastName = last;
        email = em;
        hourlyWage = rate;
        dateOfBirth = bd;
        employeeType = EmpType;
    } // this is the constructor
    

// a constructor is a method that is called when an object is created and it has same name as the class and no return type
    public void PerformWork()
    {
        //numberOfHoursWorked++; call the other perform work method to do the same thing
        PerformWork(minimalHoursWorkedUnit);
        //Console.WriteLine($"{firstName} {lastName} has worked for {numberOfHoursWorked} hours"); // this line is now in the other method
    }
    public void PerformWork(int numberOfHours)
    {
        numberOfHoursWorked += numberOfHours;
        Console.WriteLine($"{firstName} {lastName} has worked for {numberOfHoursWorked} hours");
    }

    public int CalculateBonus(int bonus)
    {
       if (numberOfHoursWorked > 10)
       bonus *= 2;

       Console.WriteLine($" The employee goat a bonus of {bonus}");
         return bonus;
    }
    public double ReceiveWage(bool resetHours = true) // default value for resetHours is true and its optional parameter
    {
        if (employeeType == EmployeeType.Manager)
        {
            Console.WriteLine($" An extra was added to the wage since {firstName} is a manager!");
            wage = hourlyWage * numberOfHoursWorked * 1.25;
        }
        else
        {
            wage = hourlyWage * numberOfHoursWorked;
        }

        Console.WriteLine($"{firstName} {lastName} has received a wage of {wage} for {numberOfHoursWorked} hours worked");
        if (resetHours)
        {
            numberOfHoursWorked = 0;
        }
        return wage;
    }
    public void DisplayEmployeeDetails()
    {
        Console.WriteLine($"\nFirst name: {firstName}\nLast name: {lastName}\nEmail: {email}\nDate of birth: {dateOfBirth.ToShortDateString()}\n");

    }


}

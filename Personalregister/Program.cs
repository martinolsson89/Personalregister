namespace Personalregister;

// Employee: Class that represents an employee with ID, Name and Salary.

// IEmployeeRepository / InMemoryEmployeeRepository: Handles in-memory storage of employees. Can easily be replaced with database storage.

// EmployeeService: Contains logic for adding, listing employees.

// ConsoleUi: Manages the console user interface ( menu, input validation, and displaying the registry. )

public class Program
{
    static void Main(string[] args)
    {
        var repo = new InMemoryEmployeeRepository();
        var service = new EmployeeService(repo);

        var ui = new ConsoleUi(service);
        ui.Run();
    }
}

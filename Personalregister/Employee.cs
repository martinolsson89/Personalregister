namespace Personalregister;
public class Employee
{
    public int Id { get; init; }
    public string Name { get; init; }
    public decimal Salary { get; init; }

    private Employee(int id, string name, decimal salary)
    {
        Id = id;
        Name = name;
        Salary = salary;
    }

    public static bool TryCreate(int id, string name, decimal salary, out Employee? employee, out string? error)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            employee = null;
            error = "Namn får inte vara tomt.";
            return false;
        }

        name = name.Trim();

        if (salary < 0)
        {
            employee = null;
            error = "Lön måste vara > 0.";
            return false;
        }

        employee = new Employee(id, name, salary);
        error = null;
        return true;
    }

}


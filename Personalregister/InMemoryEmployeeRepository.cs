namespace Personalregister;

public class InMemoryEmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees = new();
    private int _nextId = 1;
    public Employee Add(Employee employee)
    {
        _employees.Add(employee);
        return employee;
    }

    public IReadOnlyList<Employee> GetAll() => _employees;

    public int NextId() => _nextId++;
}

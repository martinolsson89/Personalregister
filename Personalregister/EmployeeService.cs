namespace Personalregister;

public class EmployeeService
{
    private readonly IEmployeeRepository _repo;

    public EmployeeService(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    public (bool ok, string? error, Employee? employee) Add(string name, decimal salary)
    {
        var id = _repo.NextId();

        if(!Employee.TryCreate(id, name, salary, out var emp, out var error))
        {
            return (false, error, null);
        }

        _repo.Add(emp!);
        return (true, null, emp);
    }
    public IReadOnlyList<Employee> List() => _repo.GetAll();
}


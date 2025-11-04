namespace Personalregister;

public interface IEmployeeRepository
{
    Employee Add(Employee employee);
    IReadOnlyList<Employee> GetAll();
    int NextId();
}

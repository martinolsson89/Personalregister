namespace Personalregister.Tests;

public class EmployeeServiceTests
{
    [Fact]
    public void Add_Succeeds_WithValidInput_AndPersistsInRepo()
    {
        // Arrange
        var repo = new InMemoryEmployeeRepository();
        var svc = new EmployeeService(repo);

        // Act
        var r = svc.Add("  Anna  ", 30000m);
        var list = svc.List();

        // Assert
        Assert.True(r.ok);
        Assert.Null(r.error);
        Assert.NotNull(r.employee);
        Assert.Equal(1, r.employee!.Id);
        Assert.Equal("Anna", r.employee.Name);
        Assert.Equal(30000m, r.employee.Salary);

        Assert.Single(list);
        Assert.Equal("Anna", list[0].Name);
    }

    [Fact]
    public void Add_Fails_When_NameIsEmpty()
    {
        // Arrange
        var repo = new InMemoryEmployeeRepository();
        var svc = new EmployeeService(repo);

        // Act
        var r = svc.Add("   ", 10000m);

        // Assert
        Assert.False(r.ok);
        Assert.Null(r.employee);
        Assert.NotNull(r.error);
        Assert.Empty(svc.List());
    }

    [Fact]
    public void Add_Fails_When_SalaryNegative()
    {
        // Arrange
        var repo = new InMemoryEmployeeRepository();
        var svc = new EmployeeService(repo);

        // Act
        var r = svc.Add("Anna", -1m);

        // Assert
        Assert.False(r.ok);
        Assert.Null(r.employee);
        Assert.NotNull(r.error);
        Assert.Empty(svc.List());
    }

    [Fact]
    public void List_ReturnsAll_AfterMultipleAdds()
    {
        // Arrange
        var repo = new InMemoryEmployeeRepository();
        var svc = new EmployeeService(repo);

        // Act
        svc.Add("Anna", 30000m);
        svc.Add("Bertil", 25000m);
        var list = svc.List();

        // Assert
        Assert.Equal(2, list.Count);
        Assert.Contains(list, e => e.Name == "Anna" && e.Salary == 30000m);
        Assert.Contains(list, e => e.Name == "Bertil" && e.Salary == 25000m);
    }
}

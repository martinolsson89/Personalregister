namespace Personalregister.Tests;

public class EmployeeTests
{
    [Fact]
    public void TryCreate_Fails_When_Name_Is_Empty()
    {
        // Act
        var ok = Employee.TryCreate(1, "   ", 10000m, out var emp, out var error);

        // Assert
        Assert.False(ok);
        Assert.Null(emp);
        Assert.Contains("Namn", error, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void TryCreate_Fails_When_Salary_Negative()
    {
        // Act
        var ok = Employee.TryCreate(1, "Anna", -1m, out var emp, out var error);

        // Assert
        Assert.False(ok);
        Assert.Null(emp);
        Assert.Contains("Lön", error!, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void TryCreate_Succeed_When_Valid_Input()
    {
        // Act
        var ok = Employee.TryCreate(1, "Eric", 25000m, out var emp, out var error);

        // Assert
        Assert.True(ok);
        Assert.Null(error);
        Assert.NotNull(emp);

        Assert.Equal(1, emp!.Id);
        Assert.Equal("Eric", emp.Name);
        Assert.Equal(25000m, emp.Salary);
    }


}

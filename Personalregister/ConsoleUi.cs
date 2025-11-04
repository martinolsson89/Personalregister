namespace Personalregister;

public class ConsoleUi
{
    private readonly EmployeeService _service;

    public ConsoleUi(EmployeeService service)
    {
        _service = service;
    }

    public void Run()
    {
        while (true)
        {
            PrintMenu();
            var choice = ReadInput("Välj ett alternativ: ");

            switch (choice)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                    PrintRegistry();
                    break;
                case "0":
                    Console.WriteLine("Avslutar...");
                    return;
                default:
                    Console.WriteLine("Ogiltigt val.\n");
                    break;
            }
        }
    }

    private void PrintMenu()
    {
        Console.WriteLine("==== Personalregister ====");
        Console.WriteLine("1) Lägg till anställd");
        Console.WriteLine("2) Skriv ut registret");
        Console.WriteLine("0) Avsluta");
        Console.WriteLine();
    }

    private void AddEmployee()
    {
        var name = ReadString("Namn: ");
        var salary = ReadDecimal("Lön (kr): ");

        var (ok, error, employee) = _service.Add(name, salary);
        if (!ok)
        {
            Console.WriteLine($"Misslyckades: {error}\n");
            return;
        }

        Console.WriteLine($"Tillagd: [{employee!.Id}] {employee.Name} – Lön: {employee.Salary} kr\n");
    }

    private void PrintRegistry()
    {
        var all = _service.List();

        if (all.Count == 0)
        {
            Console.WriteLine("Registret är tomt.\n");
            return;
        }

        Console.WriteLine("\nID  Namn                          Lön");
        Console.WriteLine("-----------------------------------------------");
        foreach (var e in all)
        {
            Console.WriteLine($"{e.Id,-3} {e.Name,-28} {e.Salary} kr");
        }

        Console.WriteLine();
    }

    private string ReadInput(string prompt)
    {
        Console.Write(prompt);
        return (Console.ReadLine() ?? string.Empty).Trim();
    }

    private string ReadString(string prompt)
    {
        while (true)
        {
            var s = ReadInput(prompt);
            if (!string.IsNullOrWhiteSpace(s))
                return s;

            Console.WriteLine("Värdet får inte vara tomt.");
        }
    }

    private decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            var s = ReadInput(prompt);
            if (decimal.TryParse(s, out var value))
                return value;

            Console.WriteLine("Ange en giltig tal (t.ex. 28 000).");
        }
    }
}

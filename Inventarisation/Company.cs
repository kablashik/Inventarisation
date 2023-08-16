namespace Inventarisation;

/// <summary>
/// В компании по умолчанию будет создано три сотрудника:
/// Директор, менеджер и кладовищк
/// </summary>
public class Company
{
    public string Name { get; }
    public readonly WareHouse WareHouse = new WareHouse();

    private List<Employee> _employeesList = new List<Employee>()
    {
        new Employee("Илья Владимирович", "Директор"),
        new Employee("Ольга Сергеевна", "Менеджер по продажам"),
        new Employee("Пётр Васильевич", "Кладовщик"),
    };

    public Company(string name)
    {
        Name = name;
        MainMenu menu = new MainMenu();
        menu.ShowMenu(this);
    }

    public void HireNewEmployee()
    {
        Console.Clear();
        Console.WriteLine("Введите ИО нового сотрудника");
        string name = Console.ReadLine();
        Console.WriteLine("Введите должность нового сотрудника");
        string position = Console.ReadLine();
        _employeesList.Add(new Employee(name, position));
        Console.Clear();
        Console.WriteLine($"Работник {name} успешно принят в компанию {Name} " +
                          $"на должность {position}");
    }

    public void BuyNewInventory()
    {
        Console.Clear();
        Console.WriteLine("Выберите тип инвентаря" +
                          "\n 1 - Laptop" +
                          "\n 2 - Printer" +
                          "\n 3 - Table");

        int userChoice = Convert.ToInt32(Console.ReadLine());
        if (userChoice > 3)
        {
            Console.WriteLine("Неверный ввод");
            return;
        }

        Console.Clear();
        Console.WriteLine("Введите производителя инвентаря: ");
        string manufacturer = Console.ReadLine();
        Console.WriteLine("Введите модель/характеристику инвентаря:");
        string model = Console.ReadLine();

        switch ((InventoryEnum)userChoice)
        {
            case InventoryEnum.Laptop:
                WareHouse.ReceiveInventory(new Laptop(manufacturer, model, WareHouse.GetFreeInventoryNumber()));
                break;
            case InventoryEnum.Printer:
                WareHouse.ReceiveInventory(new Printer(manufacturer, model, WareHouse.GetFreeInventoryNumber()));
                break;
            case InventoryEnum.Table:
                WareHouse.ReceiveInventory(new Table(manufacturer, model, WareHouse.GetFreeInventoryNumber()));
                break;
            default:
                Console.WriteLine("Неверный ввод");
                break;
        }
    }

    public void PrintEmployeeList()
    {
        Console.Clear();
        Console.WriteLine("Список сотрудников: ");
        int i = 1;
        foreach (var employee in _employeesList)
        {
            Console.WriteLine($"{i}. {employee.Name} - {employee.Position}");
            i++;
        }
    }

    public Employee FindExactEmployee()
    {
        PrintEmployeeList();
        Console.WriteLine("Введите номер сотруника: ");
        int number = Convert.ToInt32(Console.ReadLine()) - 1;

        while (number >= _employeesList.Count)
        {
            PrintEmployeeList();
            Console.WriteLine("Неверный ввод");
            Console.WriteLine("Введите номер сотруника: ");
            number = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Clear();
        }

        return _employeesList[number];
    }

    private enum InventoryEnum
    {
        Laptop = 1,
        Printer,
        Table,
    }
}
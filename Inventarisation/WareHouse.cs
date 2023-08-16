namespace Inventarisation;

/// <summary>
///Класс склад по умолчанию будет содержать список из девяти
///зарнее созданных единиц инвентаря
/// </summary>
public class WareHouse
{
    private List<Inventory> _inventoryList = new List<Inventory>
    {
        new Laptop("Honor", "MagicBook PRO", 36),
        new Laptop("Honor", "MagicBook PRO", 37),
        new Laptop("Honor", "MagicBook PRO", 38),
        new Table("Ami мебель", "Венге", 39),
        new Table("Ami мебель", "Венге", 40),
        new Table("Ami мебель", "Венге", 41),
        new Printer("HP", "M401", 42),
        new Printer("HP", "M401", 43),
        new Printer("HP", "M401", 44),
    };

    private int _inventoryNumber = 45;

    public void SendInventory(Employee employee)
    {
        Console.Clear();

        PrintInventoryList();
        Console.WriteLine("Введите номер предмета, который хотите выдать работнику");
        var number = Convert.ToInt32(Console.ReadLine()) - 1;

        if (number <= _inventoryList.Count)
        {
            Console.Clear();
            employee.ReceiveInventory(_inventoryList[number]);
            Console.WriteLine(
                $"{_inventoryList[number].GetType().Name} {_inventoryList[number].GetInventoryManufacturer()}" +
                $" успешно передан работнику" +
                $" {employee.Name}");
            _inventoryList.RemoveAt(number);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Инвентаря с таким номером не существует");
        }
    }

    public void ReceiveInventory(Inventory inventory)
    {
        Console.Clear();
        _inventoryList.Add(inventory);
        _inventoryNumber++;
        Console.WriteLine(
            $"Инвентарь {inventory.GetType().Name} {inventory.GetInventoryManufacturer()} успешно передан на склад");
    }

    public int GetFreeInventoryNumber()
    {
        return _inventoryNumber;
    }

    public void PrintInventoryList()
    {
        Console.Clear();
        Console.WriteLine("Доступный инвентарь на складе:");

        var i = 0;
        foreach (var inventory in _inventoryList)
        {
            Console.Write($"№{i + 1} - ");
            inventory.PrintInfo();
            i++;
        }
    }

    public void WriteInventoryListToTxt()
    {
        Console.Clear();
        Console.WriteLine($"Текстовый файл \"Report.txt\" создан в катологе: \n{Path.GetFullPath("Report.txt")}");
        var report = new StreamWriter("Report.txt");

        foreach (var inventory in _inventoryList)
        {
            report.Write(inventory.ReturnStringInfo() + "\n");
        }

        report.Close();
    }
}
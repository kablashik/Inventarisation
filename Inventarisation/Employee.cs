namespace Inventarisation;

public class Employee
{
    public string Name { get; }
    public string Position { get; }
    private List<Inventory> _inventoryList = new List<Inventory>();

    public Employee(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public void ReceiveInventory(Inventory item)
    {
        _inventoryList.Add(item);
    }

    public void SendInventory(WareHouse wareHouse)
    {
        Console.Clear();
        if (_inventoryList.Count == 0)
        {
            Console.WriteLine("На сотруднике ничего не числится \n");
            return;
        }

        Console.WriteLine("Список инвентаря, который числится на работнике:");
        PrintInventoryList();

        Console.WriteLine("Введите номер предмета, который хотите сдать на склад:");
        var number = Convert.ToInt32(Console.ReadLine()) - 1;
        wareHouse.ReceiveInventory(_inventoryList[number]);

        _inventoryList.RemoveAt(number);
    }

    public void PrintInventoryList()
    {
        Console.Clear();
        if (_inventoryList.Count != 0)
        {
            var i = 0;
            foreach (var inventory in _inventoryList)
            {
                Console.Write($"{i + 1}. ");
                inventory.PrintInfo();
                i++;
            }
        }
        else
        {
            Console.WriteLine("На сотруднике ничего не числится \n");
        }
    }

    public void WriteEmployeeInventoryListToTxt()
    {
        Console.Clear();
        if (_inventoryList.Count != 0)
        {
            Console.Clear();
            Console.WriteLine(
                $"Текстовый файл \"Employers_Report.txt\" создан в катологе: \n{Path.GetFullPath("Report.txt")}");
            var report = new StreamWriter("Employers_Report.txt");

            report.Write($"На работнике {Name} числится:\n");
            foreach (var inventory in _inventoryList)
            {
                report.Write(inventory.ReturnStringInfo() + "\n");
            }

            report.Close();
        }
        else
        {
            Console.WriteLine("На сотруднике ничего не числится \n");
        }
    }
}
using Inventarisation;

namespace Inventarisation;

public abstract class Inventory
{
    private string Manufacturer { get; }
    private int InventoryNumber { get; }

    public Inventory(string manufacturer, int inventoryNumber)
    {
        Manufacturer = manufacturer;
        InventoryNumber = inventoryNumber;
    }

    public virtual void PrintInfo()
    {
        Console.Write($"Инв. номер - {InventoryNumber}, Тип - {GetType().Name}, Производитель - {Manufacturer}, ");
    }

    public virtual string ReturnStringInfo()
    {
        return $"Инв. номер - {InventoryNumber}, Тип - {GetType().Name}, Производитель - {Manufacturer}, ";
    }

    public string GetInventoryManufacturer()
    {
        return Manufacturer;
    }
}

public class Laptop : Inventory
{
    private string Manufacturer { get; }
    private string Model { get; }

    public Laptop(string manufacturer, string model, int inventoryNumber) : base(manufacturer, inventoryNumber)
    {
        Manufacturer = manufacturer;
        Model = model;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Модель - {Model}");
    }

    public override string ReturnStringInfo()
    {
        return base.ReturnStringInfo() + $"Модель - {Model}";
    }
}

public class Table : Inventory
{
    private string Colour { get; }

    public Table(string manufacturer, string colour, int inventoryNumber) : base(manufacturer, inventoryNumber)
    {
        Colour = colour;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Цвет - {Colour}");
    }

    public override string ReturnStringInfo()
    {
        return base.ReturnStringInfo() + $"Цвет - {Colour}";
    }
}

public class Printer : Laptop
{
    public Printer(string manufacturer, string model, int inventoryNumber)
        : base(manufacturer, model, inventoryNumber)
    {
    }
}
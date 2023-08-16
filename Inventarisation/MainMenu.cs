namespace Inventarisation;

public class MainMenu
{
    public void ShowMenu(Company company)
    {
        Console.WriteLine($"Здравствуйте, вас приветсвует компания {company.Name} \n");
        Pause();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Выберите действие:");
            var menu = new Dictionary<byte, string>()
            {
                { 1, "Купить новый инвентарь на склад" },
                { 2, "Нанять нового сотрудника" },
                { 3, "Передать инвентарь сотруднику" },
                { 4, "Списать инвентарь с сотрудника" },
                { 5, "Посмотреть инвентарь на сотруднике" },
                { 6, "Посмотреть весь инвентарь на складе" },
                { 7, "Экспортировать инвентарь работника в .txt файл" },
                { 8, "Экспортировать складской инвентарь в .txt файл" },
            };

            foreach (var keyValuePair in menu)
            {
                Console.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value}");
            }

            ProcessingUsersRequests(company);
        }
    }

    private void ProcessingUsersRequests(Company company)
    {
        int userChoice;
        int.TryParse(Console.ReadLine(), out userChoice);

        switch ((Actions)userChoice)
        {
            case Actions.AddInventory:
                company.BuyNewInventory();
                Pause();
                break;
            case Actions.AddEmployee:
                company.HireNewEmployee();
                Pause();
                break;
            case Actions.GiveInventoryToEmployee:
                company.WareHouse.SendInventory(company.FindExactEmployee());
                Pause();
                break;
            case Actions.ReturnInventoryToWareHouse:
                company.FindExactEmployee().SendInventory(company.WareHouse);
                Pause();
                break;
            case Actions.WareHousePrintInventoryList:
                company.WareHouse.PrintInventoryList();
                Pause();
                break;
            case Actions.EmployeePrintInventoryList:
                company.FindExactEmployee().PrintInventoryList();
                Pause();
                break;
            case Actions.WriteEmployeeInventoryListToTxt:
                company.FindExactEmployee().WriteEmployeeInventoryListToTxt();
                Pause();
                break;
            case Actions.WriteInventoryToTxt:
                company.WareHouse.WriteInventoryListToTxt();
                Pause();
                break;
            default:
                Console.WriteLine("Неверный ввод");
                Pause();
                break;
        }
    }

    public static void Pause()
    {
        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
        Console.ReadKey(true);
    }
}
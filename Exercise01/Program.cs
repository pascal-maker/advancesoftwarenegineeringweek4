using Howest.Week04.Repositories;
using Howest.Week04.Services;
using Howest.Week04.Models;

class Program
{
    static void Main()
    {
        var csvRepo = new CsvFileRepository();
        var smartphoneService = new SmartphoneService(csvRepo);

        while (true)
        {
            Console.WriteLine("\nSmartphone Catalog");
            Console.WriteLine("1. List all smartphones");
            Console.WriteLine("2. Search smartphone by ID");
            Console.WriteLine("3. Add new smartphone");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    foreach (var s in smartphoneService.GetSmartphones())
                        Console.WriteLine(s);
                    break;

                case "2":
                    Console.Write("Enter smartphone ID: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        var phone = smartphoneService.GetSmartphoneById(id);
                        Console.WriteLine(phone ?? "Smartphone not found.");
                    }
                    break;

                case "3":
                    Console.Write("Enter smartphone name: ");
                    string? name = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Invalid name. Please try again.");
                        break;
                    }

                    Smartphone newPhone = new Smartphone(name, "Android", 64, 4, 150, "Samsung", 5.8);
                    smartphoneService.AddSmartphone(newPhone);
                    Console.WriteLine("Smartphone added successfully.");
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

using System.Globalization;
using System.IO;
using CsvHelper;
using Howest.Week04.Models;

namespace Howest.Week04.Repositories;

public class CsvFileRepository : IFileRepository
{
    private const string csvFile = "csvfiles/smartphones.csv";

    public List<Smartphone> GetSmartphones()
    {
        if (!File.Exists(csvFile)) return new List<Smartphone>();

        using (var reader = new StreamReader(csvFile))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<Smartphone>().ToList();
        }
    }

    public Smartphone GetSmartphoneById(int id)
    {
        return GetSmartphones().FirstOrDefault(s => s.Id == id);
    }

    public void AddSmartphone(Smartphone smartphone)
    {
        ArgumentNullException.ThrowIfNull(smartphone);
        var smartphones = GetSmartphones();
        smartphone.Id = smartphones.Any() ? smartphones.Max(s => s.Id) + 1 : 1;
        smartphones.Add(smartphone);

        using (var writer = new StreamWriter(csvFile))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(smartphones);
        }
    }
}

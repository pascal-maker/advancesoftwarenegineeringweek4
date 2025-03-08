namespace Howest.Week04.Models;

public class Smartphone
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Os { get; set; }
    public int Capacity { get; set; }
    public int Ram { get; set; }
    public int Weight { get; set; }
    public string Company { get; set; }
    public double Inch { get; set; }

    public Smartphone(string name, string os, int capacity, int ram, int weight, string company, double inch)
    {
        if (string.IsNullOrEmpty(name)) throw new InvalidNameException(nameof(name));
        if (string.IsNullOrEmpty(os)) throw new InvalidNameException(nameof(os));
        if (capacity < 0) throw new InvalidNameException(nameof(capacity));
        if (ram < 0) throw new InvalidNameException(nameof(ram));
        if (weight < 0) throw new InvalidNameException(nameof(weight));
        if (string.IsNullOrEmpty(company)) throw new InvalidNameException(nameof(company));
        if (inch < 0) throw new InvalidNameException(nameof(inch));

        Name = name;
        Os = os;
        Capacity = capacity;
        Ram = ram;
        Weight = weight;
        Company = company;
        Inch = inch;
    }

    public override string ToString()
    {
        return $"{Name}: {Os}, {Capacity}GB, {Ram}GB RAM, {Weight}g, {Company}, {Inch}\" Screen";
    }
}

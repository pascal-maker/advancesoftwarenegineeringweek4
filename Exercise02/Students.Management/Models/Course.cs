namespace Students.Management.Library.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    // Use double for Price, per your usage
    public double Price { get; set; }

    // Paramless constructor for object initializers like new Course { ... }
    public Course()
    {
    }

    // Full constructor if needed
    public Course(int id, string title, double price)
    {
        Id = id;
        Title = title;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Id}, {Title}, €{Price}";
    }
}

namespace Students.Management.Library.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Matches your usage in Program.cs
    public string Class { get; set; } = string.Empty; 

    public DateTime EnrollmentDate { get; set; }

    // Paramless constructor for object initializers like new Student { ... }
    public Student()
    {
        EnrollmentDate = DateTime.Now;
    }

    // Full constructor if needed
    public Student(int id, string name, string email, string @class, DateTime enrollmentDate)
    {
        Id = id;
        Name = name;
        Email = email;
        Class = @class;
        EnrollmentDate = enrollmentDate;
    }

    public override string ToString()
    {
        return $"{Id}, {Name}, {Email}, {Class}, {EnrollmentDate.ToShortDateString()}";
    }
}

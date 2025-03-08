using System;

namespace Students.Management.Library.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}, {Email}, {Class}, {EnrollmentDate.ToShortDateString()}";
        }
    }
}

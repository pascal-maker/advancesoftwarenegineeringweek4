using System;

namespace Students.Management.Library.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Title}, €{Price}";
        }
    }
}

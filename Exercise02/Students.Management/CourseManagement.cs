using System;
using System.Collections.Generic;
using System.Linq;

public static class CourseManagement
{
    // Lists to hold students and courses
    private static List<Student> students = new List<Student>();
    private static List<Course> courses = new List<Course>();

    // List all students or indicate if none exist
    public static void ListStudents()
    {
        if (students == null || students.Count == 0)
        {
            Console.WriteLine("No students available.");
        }
        else
        {
            Console.WriteLine("Students:");
            foreach (Student s in students)
            {
                // Safely convert the student to a string (uses Student.ToString if overridden)
                Console.WriteLine(s?.ToString() ?? string.Empty);
            }
        }
    }

    // List all courses or indicate if none exist
    public static void ListCourses()
    {
        if (courses == null || courses.Count == 0)
        {
            Console.WriteLine("No courses available.");
        }
        else
        {
            Console.WriteLine("Courses:");
            foreach (Course c in courses)
            {
                Console.WriteLine(c?.ToString() ?? string.Empty);
            }
        }
    }

    // Add a new student to the list (if not null and ID not duplicate)
    public static void AddStudent(Student student)
    {
        if (student == null)
        {
            Console.WriteLine("Cannot add a null student.");
            return;
        }
        if (students == null) students = new List<Student>();  // ensure list is initialized
        // Prevent adding a student with an ID that already exists
        if (students.Any(s => s.Id == student.Id))
        {
            Console.WriteLine("A student with this ID already exists.");
        }
        else
        {
            students.Add(student);
            Console.WriteLine("Student added successfully.");
        }
    }

    // Add a new course to the list (if not null and ID not duplicate)
    public static void AddCourse(Course course)
    {
        if (course == null)
        {
            Console.WriteLine("Cannot add a null course.");
            return;
        }
        if (courses == null) courses = new List<Course>();  // ensure list is initialized
        if (courses.Any(c => c.Id == course.Id))
        {
            Console.WriteLine("A course with this ID already exists.");
        }
        else
        {
            courses.Add(course);
            Console.WriteLine("Course added successfully.");
        }
    }

    // Find a student by ID (returns null if not found)
    public static Student FindStudentById(int id)
    {
        if (students == null) return null;
        return students.FirstOrDefault(s => s.Id == id);
    }

    // Find a course by ID (returns null if not found)
    public static Course FindCourseById(int id)
    {
        if (courses == null) return null;
        return courses.FirstOrDefault(c => c.Id == id);
    }
}

// Sample Student class (for completeness)
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string ClassName { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public Student(int id, string name, string email, string className, DateTime enrollmentDate)
    {
        Id = id;
        Name = name;
        Email = email;
        ClassName = className;
        EnrollmentDate = enrollmentDate;
    }

    // Override ToString for meaningful output
    public override string ToString()
    {
        return $"{Id}: {Name} - {Email} - {ClassName} (Enrolled: {EnrollmentDate.ToShortDateString()})";
    }
}

// Sample Course class (for completeness)
public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }

    // Constructor accepts all required parameters (ID, Title, Price)
    public Course(int id, string title, double price)
    {
        Id = id;
        Title = title;
        Price = price;
    }

    // Override ToString for meaningful output
    public override string ToString()
    {
        return $"{Id}: {Title} (${Price})";
    }
}

using System;
using Students.Management.Library.Models;
using Students.Management.Library.Repositories;
using Students.Management.Library.Services;

class Program
{
    static void Main()
    {
        IFileRepository csvRepo = new CsvFileRepository();
        var studentService = new StudentService(csvRepo);
        var courseService = new CourseService(csvRepo);

        while (true)
        {
            Console.WriteLine("\nCourse Management System");
            Console.WriteLine("1. List all students");
            Console.WriteLine("2. Search student by ID");
            Console.WriteLine("3. Add a new student");
            Console.WriteLine("4. List all courses");
            Console.WriteLine("5. Search course by ID");
            Console.WriteLine("6. Add a new course");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var allStudents = studentService.GetStudents();
                    if (allStudents.Count == 0)
                        Console.WriteLine("No students found.");
                    else
                        foreach (var s in allStudents) Console.WriteLine(s);
                    break;

                case "2":
                    Console.Write("Enter student ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int studentId))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }
                    var stud = studentService.GetStudentById(studentId);
                    Console.WriteLine(stud?.ToString() ?? "Student not found.");
                    break;

                case "3":
                    Console.Write("Student name: ");
                    string? sName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(sName))
                    {
                        Console.WriteLine("Invalid name.");
                        break;
                    }
                    Console.Write("Student email: ");
                    string? sEmail = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(sEmail))
                    {
                        Console.WriteLine("Invalid email.");
                        break;
                    }
                    Console.Write("Student class: ");
                    string? sClass = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(sClass))
                    {
                        Console.WriteLine("Invalid class.");
                        break;
                    }
                    var newStudent = new Student 
                    {
                        // ID auto-assigned in repository
                        Name = sName,
                        Email = sEmail,
                        Class = sClass,
                        EnrollmentDate = DateTime.Now
                    };
                    studentService.AddStudent(newStudent);
                    Console.WriteLine("New student added.");
                    break;

                case "4":
                    var allCourses = courseService.GetCourses();
                    if (allCourses.Count == 0)
                        Console.WriteLine("No courses found.");
                    else
                        foreach (var c in allCourses) Console.WriteLine(c);
                    break;

                case "5":
                    Console.Write("Enter course ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int courseId))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }
                    var crs = courseService.GetCourseById(courseId);
                    Console.WriteLine(crs?.ToString() ?? "Course not found.");
                    break;

                case "6":
                    Console.Write("Course title: ");
                    string? title = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(title))
                    {
                        Console.WriteLine("Invalid title.");
                        break;
                    }
                    Console.Write("Course price: ");
                    if (!double.TryParse(Console.ReadLine(), out double price))
                    {
                        Console.WriteLine("Invalid price.");
                        break;
                    }
                    var newCourse = new Course
                    {
                        // ID auto-assigned in repository
                        Title = title,
                        Price = price
                    };
                    courseService.AddCourse(newCourse);
                    Console.WriteLine("New course added.");
                    break;

                case "7":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

using System;

public class Program
{
    public static void Main()
    {
        int choice = -1;
        do
        {
            // Display menu options
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. List Students");
            Console.WriteLine("2. List Courses");
            Console.WriteLine("3. Add Student");
            Console.WriteLine("4. Add Course");
            Console.WriteLine("5. Enroll Student in Course");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            
            string input = Console.ReadLine();
            if (!int.TryParse(input, out choice))
            {
                // Input was not a valid integer
                Console.WriteLine("Invalid input. Please enter a number from the menu options.");
                choice = -1;
                continue;  // skip to next iteration to ask again
            }

            switch (choice)
            {
                case 1:
                    // List all students
                    CourseManagement.ListStudents();
                    break;
                
                case 2:
                    // List all courses
                    CourseManagement.ListCourses();
                    break;
                
                case 3:
                    // Add a new student (with input validation)
                    Console.Write("Enter Student ID: ");
                    string sidInput = Console.ReadLine();
                    if (!int.TryParse(sidInput, out int newStudentId))
                    {
                        Console.WriteLine("Invalid ID. Please enter a numeric value.");
                        break;
                    }
                    Console.Write("Enter Name: ");
                    string studentName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(studentName))
                    {
                        Console.WriteLine("Name cannot be empty.");
                        break;
                    }
                    Console.Write("Enter Email: ");
                    string studentEmail = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(studentEmail))
                    {
                        Console.WriteLine("Email cannot be empty.");
                        break;
                    }
                    Console.Write("Enter Class Name: ");
                    string className = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(className))
                    {
                        Console.WriteLine("Class Name cannot be empty.");
                        break;
                    }
                    // For enrollment date, use current date (or prompt user if required)
                    DateTime enrollmentDate = DateTime.Now;
                    
                    // Create Student object and add to list
                    Student newStudent = new Student(newStudentId, studentName, studentEmail, className, enrollmentDate);
                    CourseManagement.AddStudent(newStudent);
                    break;
                
                case 4:
                    // Add a new course (with input validation)
                    Console.Write("Enter Course ID: ");
                    string cidInput = Console.ReadLine();
                    if (!int.TryParse(cidInput, out int newCourseId))
                    {
                        Console.WriteLine("Invalid ID. Please enter a numeric value.");
                        break;
                    }
                    Console.Write("Enter Course Title: ");
                    string courseTitle = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(courseTitle))
                    {
                        Console.WriteLine("Course title cannot be empty.");
                        break;
                    }
                    Console.Write("Enter Course Price: ");
                    string priceInput = Console.ReadLine();
                    if (!double.TryParse(priceInput, out double coursePrice))
                    {
                        Console.WriteLine("Invalid price. Please enter a numeric value.");
                        break;
                    }
                    
                    // Create Course object and add to list
                    Course newCourse = new Course(newCourseId, courseTitle, coursePrice);
                    CourseManagement.AddCourse(newCourse);
                    break;
                
                case 5:
                    // Enroll a student in a course (by IDs)
                    Console.Write("Enter Student ID to enroll: ");
                    string enrollStudInput = Console.ReadLine();
                    Console.Write("Enter Course ID to enroll in: ");
                    string enrollCourseInput = Console.ReadLine();
                    if (!int.TryParse(enrollStudInput, out int enrollStudentId) ||
                        !int.TryParse(enrollCourseInput, out int enrollCourseId))
                    {
                        Console.WriteLine("Invalid input. Please enter numeric values for IDs.");
                        break;
                    }
                    
                    Student studentToEnroll = CourseManagement.FindStudentById(enrollStudentId);
                    Course courseToEnroll = CourseManagement.FindCourseById(enrollCourseId);
                    if (studentToEnroll == null || courseToEnroll == null)
                    {
                        // Handle nulls gracefully by informing the user
                        if (studentToEnroll == null) Console.WriteLine("Student not found.");
                        if (courseToEnroll == null) Console.WriteLine("Course not found.");
                    }
                    else
                    {
                        // Normally, we would record this enrollment in a list or database
                        // Here we just confirm the action, using ?? to safely convert objects to strings
                        Console.WriteLine(
                            $"{studentToEnroll?.ToString() ?? "Unknown Student"} enrolled in " + 
                            $"{courseToEnroll?.ToString() ?? "Unknown Course"} successfully."
                        );
                    }
                    break;
                
                case 0:
                    // Exit the program
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                
                default:
                    // Choice is outside the expected range
                    Console.WriteLine("Please select a valid option from the menu.");
                    break;
            }
        }
        while (choice != 0);
    }
}

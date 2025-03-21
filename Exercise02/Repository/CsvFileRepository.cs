using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Students.Management.Library.Models;

namespace Students.Management.Library.Repositories;

public class CsvFileRepository : IFileRepository
{
    private const string StudentsFile = "csvfiles/students.csv";
    private const string CoursesFile = "csvfiles/courses.csv";

    // --------------------------------------------------------
    // Students
    // --------------------------------------------------------
    public List<Student> GetStudents()
    {
        if (!File.Exists(StudentsFile)) 
            return new List<Student>();

        using var reader = new StreamReader(StudentsFile);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false // set to true if first row has headers
        });

        return csv.GetRecords<Student>().ToList();
    }

    public Student? GetStudentById(int id)
    {
        return GetStudents().FirstOrDefault(s => s.Id == id);
    }

    public void AddStudent(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);
        var students = GetStudents();

        // auto-increment Id
        student.Id = students.Any() ? students.Max(s => s.Id) + 1 : 1;
        students.Add(student);

        using var writer = new StreamWriter(StudentsFile);
        using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false // set to true if you want header
        });
        csv.WriteRecords(students);
    }

    // --------------------------------------------------------
    // Courses
    // --------------------------------------------------------
    public List<Course> GetCourses()
    {
        if (!File.Exists(CoursesFile)) 
            return new List<Course>();

        using var reader = new StreamReader(CoursesFile);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        });

        return csv.GetRecords<Course>().ToList();
    }

    public Course? GetCourseById(int id)
    {
        return GetCourses().FirstOrDefault(c => c.Id == id);
    }

    public void AddCourse(Course course)
    {
        ArgumentNullException.ThrowIfNull(course);
        var courses = GetCourses();

        // auto-increment Id
        course.Id = courses.Any() ? courses.Max(c => c.Id) + 1 : 1;
        courses.Add(course);

        using var writer = new StreamWriter(CoursesFile);
        using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        });
        csv.WriteRecords(courses);
    }
}

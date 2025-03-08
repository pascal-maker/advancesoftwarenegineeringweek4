using System.Collections.Generic;
using Students.Management.Library.Models;

namespace Students.Management.Library.Repositories;

public interface IFileRepository
{
    // Students
    List<Student> GetStudents();
    Student? GetStudentById(int id);
    void AddStudent(Student student);

    // Courses
    List<Course> GetCourses();
    Course? GetCourseById(int id);
    void AddCourse(Course course);
}

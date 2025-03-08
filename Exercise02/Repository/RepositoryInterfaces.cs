using System.Runtime.CompilerServices;
using Students.Management.Library.Models;


namespace Howest.Week04.Repositories;

public interface IFileRepository
{
    List<Course> GetCourses();
    
    void GetCourses(Course course);
    void AddCourse ( Course course);
    void GetCourseById ( Course course);
    
}
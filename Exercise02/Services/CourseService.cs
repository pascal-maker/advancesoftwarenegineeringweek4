namespace Students.Management.Library.Services;
using Students.Management.Library.Models;
using Students.Management.Library.Repositories;

public class CourseService
{
    private readonly IFileRepository _courseRepository;

    public CourseService(IFileRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public List<Course> GetCourses()
    {
        return _courseRepository.GetCourses();
    }

    public Course? GetCourseById(int id)
    {
        return _courseRepository.GetCourseById(id);
    }

    public void AddCourse(Course course)
    {
        _courseRepository.AddCourse(course);
    }

    public void AddStudentToCourse(int studentId, int courseId)
    {
        _courseRepository.AddStudentToCourse(studentId, courseId);
    }
}

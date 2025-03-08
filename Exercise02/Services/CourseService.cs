using System.Collections.Generic;
using Students.Management.Library.Models;
using Students.Management.Library.Repositories;

namespace Students.Management.Library.Services;

public class CourseService
{
    private readonly IFileRepository _repo;

    public CourseService(IFileRepository repo)
    {
        _repo = repo;
    }

    public List<Course> GetCourses()
    {
        return _repo.GetCourses();
    }

    public Course? GetCourseById(int id)
    {
        return _repo.GetCourseById(id);
    }

    public void AddCourse(Course course)
    {
        _repo.AddCourse(course);
    }
}

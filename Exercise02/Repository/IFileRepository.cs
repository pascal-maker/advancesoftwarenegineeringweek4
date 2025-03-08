using System.Collections.Generic;

namespace Students.Management.Library.Repositories
{
    public interface IFileRepository
    {
        List<Student> GetStudents();
        Student GetStudentById(int id);
        void AddStudent(Student student);
        
        List<Course> GetCourses();
        Course GetCourseById(int id);
        void AddCourse(Course course);
    }
}

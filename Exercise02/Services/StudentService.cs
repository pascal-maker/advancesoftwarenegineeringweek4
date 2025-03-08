using System.Collections.Generic;
using Students.Management.Library.Models;
using Students.Management.Library.Repositories;

namespace Students.Management.Library.Services;

public class StudentService
{
    private readonly IFileRepository _repo;

    public StudentService(IFileRepository repo)
    {
        _repo = repo;
    }

    public List<Student> GetStudents()
    {
        return _repo.GetStudents();
    }

    public Student? GetStudentById(int id)
    {
        return _repo.GetStudentById(id);
    }

    public void AddStudent(Student student)
    {
        _repo.AddStudent(student);
    }
}

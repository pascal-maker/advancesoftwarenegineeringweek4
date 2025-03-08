namespace Students.Management.Library.Services;
using Students.Management.Library.Models;
using Students.Management.Library.Repositories;

public class StudentService
{
    private readonly IFileRepository _studentRepository;

    public StudentService(IFileRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public List<Student> GetStudents()
    {
        return _studentRepository.GetStudents();
    }

    public Student? GetStudentById(int id)
    {
        return _studentRepository.GetStudentById(id);
    }

    public void AddStudent(Student student)
    {
        _studentRepository.AddStudent(student);
    }
}

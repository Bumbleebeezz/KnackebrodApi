using KnackebrodApi.DataAccess.Entities;

namespace KnackebrodApi.DataAccess;

public class StudentRepository(KnackeBrodDbContext context)
{
    public List<Student> GetAllStudents()
    {
        return context.students.ToList();
    }

    public Student GetStudentId(int id)
    {

    }
}
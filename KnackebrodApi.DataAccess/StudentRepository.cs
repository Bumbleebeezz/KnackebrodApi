using KnackebrodApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnackebrodApi.DataAccess;

public class StudentRepository(KnackeBrodDbContext context)
{
    public List<Student> GetAllStudents()
    {
        return context.students.ToList();
    }

    public async Task<Student> GetStudentId(int id)
    {
        return await context.students.FirstOrDefaultAsync(s => s.Id == id);
    }

    public void AddStudent(Student student)
    {
        context.students.Add(student);
    }

    public void UpdateStudentLastName(int id, string updatedLastName)
    {

    }
}
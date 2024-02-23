using KnackebrodApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnackebrodApi.DataAccess;

public class StudentRepository(KnackeBrodDbContext context)
{
    public async Task<IEnumerable<Student>> GetAllStudents()
    {
        return context.students;
    }

    public async Task<Student?> GetStudentId(int id)
    {
        return await context.students.FindAsync(id);
    }

    public async Task AddStudent(Student student)
    {
        await context.students.AddAsync(student);

        await context.SaveChangesAsync();
    }

    public async Task UpdateStudentLastName(Student student, string updatedLastName)
    { 

       student.LastName = updatedLastName;
        
        await context.SaveChangesAsync();
    }

    public async Task RemoveStudent(int id)
    {
        var student = context.students.FirstOrDefault(s => s.Id == id);

        context.students.Remove(student);

        await context.SaveChangesAsync();
    }
}
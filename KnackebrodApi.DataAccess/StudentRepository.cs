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

        context.SaveChanges();
    }

    public async Task UpdateStudentLastName(int id, string updatedLastName)
    { 
        var updateStudentLastName =
        await context.students.FirstOrDefaultAsync(s => s.Id == id);

        if (updateStudentLastName is null)
        {
            return; 
        }

        updateStudentLastName.LastName = updatedLastName;
        
        context.SaveChanges();
    }

    public void RemoveStudent(int id)
    {
        var student = context.students.FirstOrDefault(s => s.Id == id);

        context.students.Remove(student);

        context.SaveChanges();
    }
}
using KnackebrodApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnackebrodApi.DataAccess;

public class TeacherRepository(KnackeBrodDbContext context)
{
    public List<Teacher> GetAllTeachers()
    {
        return context.teachers.ToList();
    }

    public async Task<Teacher> GetTeacherId(int id)
    {
        return await context.teachers.FirstOrDefaultAsync(t => t.Id == id);
    }

    public void AddTeacher(Teacher teacher)
    {
        context.teachers.Add(teacher);

        context.SaveChanges();
    }

    public async Task UpdateTeacherLastName(int id, string updatedLastName)
    {
        var updateTeacherLastName =
            await context.teachers.FirstOrDefaultAsync(t => t.Id == id);

        if (updateTeacherLastName is null)
        {
            return;
        }

        updateTeacherLastName.LastName = updatedLastName;

        context.SaveChanges();
    }

    public void RemoveTeacher(int id)
    {
        var teacher = context.teachers.FirstOrDefault(t => t.Id == id);

        context.teachers.Remove(teacher);

        context.SaveChanges();
    }
}
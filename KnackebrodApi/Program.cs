using KnackebrodApi.DataAccess;
using KnackebrodApi.DataAccess.Entities;

namespace KnackebrodApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<KnackeBrodDbContext>();

            builder.Services.AddScoped<StudentRepository>();

            builder.Services.AddScoped<TeacherRepository>();

            var app = builder.Build();

            #region Student

            app.MapGet("/students", (StudentRepository repo) =>
            {
                repo.GetAllStudents();
            });

            app.MapGet("/students/{id}", (StudentRepository repo, int id) =>
            {
                var results = repo.GetStudentId(id);
                if (results is null)
                {
                    return Results.BadRequest("Bananaws");
                }

                return Results.Ok(results);
            });

            app.MapPost("/studentpost", async (StudentRepository repo, Student student) =>
            {
                var existingStudent = await repo.GetStudentId(student.Id);

                if (existingStudent != null)
                {
                    return Results.BadRequest();
                }
                repo.AddStudent(student);

                return Results.Ok();

            });

            app.MapPatch("/student/{id}", async (StudentRepository repo, int id, string inputName) =>
            {
                var existingStudent = await repo.GetStudentId(id);

                if (existingStudent is null)
                {
                    return Results.BadRequest();
                }

                repo.UpdateStudentLastName(existingStudent, inputName);
                return Results.Ok();

            });
            app.MapDelete("/student/{id}", async (StudentRepository repo, int id) =>
            {
                repo.RemoveStudent(id);
                return Results.Ok();
            });

            #endregion

            #region Teacher

            app.MapGet("/teachers", (TeacherRepository repo) =>
            {
                repo.GetAllTeachers();
            });

            app.MapGet("/teachers/{id}", (TeacherRepository repo, int id) =>
            {
                var results = repo.GetTeacherId(id);
                if (results is null)
                {
                    return Results.BadRequest("Bananaws");
                }

                return Results.Ok(results);
            });

            app.MapPost("/teacherpost", async (TeacherRepository repo, Teacher teacher) =>
            {
                var existingTeacher = await repo.GetTeacherId(teacher.Id);

                if (existingTeacher != null)
                {
                    return Results.BadRequest();
                }
                repo.AddTeacher(teacher);

                return Results.Ok();

            });

            app.MapPatch("/teacher/{id}", async (TeacherRepository repo, int id, string inputName) =>
            {
                var existingTeacher = await repo.GetTeacherId(id);

                if (existingTeacher is null)
                {
                    return Results.BadRequest();
                }

                repo.UpdateTeacherLastName(existingTeacher, inputName);
                return Results.Ok();

            });
            app.MapDelete("/teacher/{id}", async (TeacherRepository repo, int id) =>
            {
                repo.RemoveTeacher(id);
                return Results.Ok();
            });

            #endregion


            app.Run();
        }
    }
}

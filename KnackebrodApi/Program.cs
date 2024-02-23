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
            app.MapPost("/studentpost", (StudentRepository repo, Student student) =>
            {

            });

            app.Run();
        }
    }
}

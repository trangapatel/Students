using Microsoft.EntityFrameworkCore;
using StudentRestAPI.Model;

namespace StudentRestAPI.Data
{
    public class ApiContext : DbContext
    {
       // public DbSet<Student> Students { get; set; }
        public DbSet<StudentModel> StudentsModel { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }

    }
}

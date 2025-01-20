
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Data{
    public class StudentDbContext(DbContextOptions<StudentDbContext>options):DbContext(options)
    {
        public DbSet <Student> Students => Set<Student>();
    }
}


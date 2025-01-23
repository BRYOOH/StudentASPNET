
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Data{
    public class StudentDbContext(DbContextOptions<StudentDbContext>options):DbContext(options)
    {
    public DbSet <Student> Students => Set<Student>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)   {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>().HasData(
             new Student{
                Id=1,
                StudentName="Brian Muriuki",
                AdminNo="SC201/0656/2018"
            },
            new Student{
                Id=2,
                StudentName="Geoffery",
                AdminNo="KIM/49381/18"
            },
            new Student{
                Id=3,
                StudentName="Brian Muriuki",
                AdminNo="SC201/0656/2018"
            }
        );
    }

    }

}


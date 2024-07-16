using GenericRepository.Model;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Data
{
    public class MyDBContextClass : DbContext
    {
        public MyDBContextClass(DbContextOptions<MyDBContextClass> options):base(options) { }

        public DbSet<Student> Students { get; set; }

    }

}

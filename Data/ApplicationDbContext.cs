using Microsoft.EntityFrameworkCore;
using StudentskaWebAPI.Models;
using System.Runtime.CompilerServices;

namespace StudentskaWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<IspitniRok> IspitniRoks { get; set; }
        public DbSet<Profesor> Profesors { get; set; }
        public DbSet<Predmet> Predmets { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Ispit> Ispits { get; set; }
        public DbSet<StudentPredmet> StudentPredmets { get; set; }
        public DbSet<Zapisnik> Zapisniks { get; set; }
    }
}

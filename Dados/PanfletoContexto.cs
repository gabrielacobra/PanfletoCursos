using Microsoft.EntityFrameworkCore;
using PanfletoCursos.Models;

namespace PanfletoCursos.Dados
{
    public class PanfletoContexto:DbContext
    {
        public PanfletoContexto(DbContextOptions<PanfletoContexto> options):base(options){

        }
        public DbSet<Area> Area { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Turma> Turma { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Area>().ToTable("Area");
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<Turma>().ToTable("Turma");
        }
    }
}
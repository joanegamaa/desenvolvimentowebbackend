using Academia.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore;
using StrongFit.Models;

namespace Academia.Models
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TreinoExercicio>()
                .HasKey(te => new { te.TreinoID, te.ExercicioID });

            modelBuilder.Entity<Treino>()
                .HasOne(t => t.Personal)
                .WithMany(p => p.Treinos)
                .HasForeignKey(t => t.PersonalID)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Personal> Personals { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<TreinoExercicio> TreinoExercicios { get; set; }
    }
}
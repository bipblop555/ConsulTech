using Microsoft.EntityFrameworkCore;
using ConsulTech.Core.Entities;

namespace ConsulTech.Core.Context
{
    public class ConsultTechContext : DbContext
    {
        public DbSet<Consultant> Consultants { get; set; } = null!;

        public DbSet<Categorie> Categories { get; set; } = null!;

        public DbSet<Client> Clients { get; set; } = null!;

        public DbSet<Competence> Competences { get; set; } = null!;

        public DbSet<Mission> Missions { get; set; } = null!;

        public DbSet<Niveau> Niveaux { get; set; } = null!;

        public ConsultTechContext(DbContextOptions<ConsultTechContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=ConsultTech;TrustServerCertificate=True;Trusted_Connection=True;");
        }
    }
}
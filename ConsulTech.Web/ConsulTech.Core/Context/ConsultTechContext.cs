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

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);

            b.Entity<Mission>()
                .HasMany(m => m.Consultants)
                .WithMany(c => c.Missions)
                .UsingEntity<Dictionary<string, object>>(
                    "MissionConsultant",
                    j => j.HasOne<Consultant>().WithMany().HasForeignKey("ConsultantId"),
                    j => j.HasOne<Mission>().WithMany().HasForeignKey("MissionId"));
        }
    }
}
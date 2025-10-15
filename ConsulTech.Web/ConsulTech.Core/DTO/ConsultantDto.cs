namespace ConsulTech.Core.DTO
{
    public sealed class ConsultantDto
    {
        public Guid Id { get; set; }

        public string Nom { get; set; } = string.Empty;

        public string Prenom { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime DateEmbauche { get; set; }

        public bool EstDisponible { get; set; }

        public List<CompetenceListDto> Competences { get; set; } = new();
    }

    public record CompetenceListDto(
        Guid Id,
        string Titre
    );
}

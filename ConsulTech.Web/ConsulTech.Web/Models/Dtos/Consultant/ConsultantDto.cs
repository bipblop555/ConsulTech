namespace ConsulTech.Web.Models.Dtos.Consultant;

public sealed record ConsultantDto
{
    public Guid Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Prenom { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DateEmbauche { get; set; }
    public bool EstDisponible { get; set; }

    public List<SkillDto> Competences { get; set; } = new();
}

public sealed record SkillDto
{
    public Guid Id { get; set; }

    public string Titre { get; set; } = string.Empty;
}
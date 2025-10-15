namespace ConsulTech.Web.Models.Dtos.Consultant;

public sealed record ConsultantDto
{
    public Guid Id { get; init; }
    public string Nom { get; init; } = string.Empty;
    public string Prenom { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public DateTime DateEmbauche { get; init; }
    public bool EstDisponible { get; init; }
}

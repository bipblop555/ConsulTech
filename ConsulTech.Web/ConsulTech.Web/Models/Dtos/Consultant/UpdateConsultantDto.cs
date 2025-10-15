namespace ConsulTech.Web.Models.Dtos.Consultant;

public sealed record UpdateConsultantDto
{
    public Guid Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Prenom { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DateEmbauche { get; set; }
    public bool EstDisponible { get; set; }
}

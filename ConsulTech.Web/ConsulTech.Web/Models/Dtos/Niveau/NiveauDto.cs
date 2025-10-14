namespace ConsulTech.Web.Models.Dtos.Niveau;

public record NiveauDto
{
    public Guid Id { get; set; }
    public string Titre { get; set; } = string.Empty;
}

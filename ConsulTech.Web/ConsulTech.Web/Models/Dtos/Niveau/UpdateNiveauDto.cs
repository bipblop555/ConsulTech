namespace ConsulTech.Web.Models.Dtos.Niveau;

public record UpdateNiveauDto
{
    public Guid Id { get; set; }
    public string Titre { get; set; } = string.Empty;
}

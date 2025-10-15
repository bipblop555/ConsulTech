namespace ConsulTech.Web.Models.Dtos.Competence;

public sealed record CreateCompetenceDto
{
    public string Titre { get; set; } = string.Empty;
    public Guid CategorieId { get; set; }
    public Guid NiveauId { get; set; }
    public Guid ConsultantId { get; set; }

}

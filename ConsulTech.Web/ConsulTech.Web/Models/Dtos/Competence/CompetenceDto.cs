using ConsulTech.Web.Models.Dtos.Categorie;
using ConsulTech.Web.Models.Dtos.Niveau;

namespace ConsulTech.Web.Models.Dtos.Competence;

public record CompetenceDto
{
    public Guid Id { get; set; }
    public string Titre { get; set; } = string.Empty;
    public CategorieDto Categorie { get; set; } = null!;
    public NiveauDto Niveau { get; set; } = null!;

    public List<Services.ConsultantsClient.ConsultantDto> Consultant { get; set; } = null!;

    public List<string> ConsultantsName { get; set; } = null!;
}
